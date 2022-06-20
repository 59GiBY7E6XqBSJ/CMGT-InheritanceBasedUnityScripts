using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject transcriptWindow;
    [SerializeField] Text title;
    [SerializeField] Text subtitle;

    [SerializeField] Animator transcriptAnimator;

    // Start is called before the first frame update
    void Start()
    {
        transcriptWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTranscript(string title, string text)
    {
        if (transcriptWindow != null)
        {
            transcriptWindow.SetActive(true);
        }

        if (transcriptAnimator != null)
        {
            transcriptAnimator.Play("Base Layer.HUDFadeInTranscript", 0, 0);
        }

        this.title.text = title;
        this.subtitle.text = text;
    }

    public void FadeoutTranscript()
    {
        if (transcriptAnimator != null)
        {
            transcriptAnimator.Play("Base Layer.HUDFadeOutTranscript", 0, 0);
        }
    }
}
