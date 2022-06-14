using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : Trigger
{
    AudioSource audioSource;

    [SerializeField] bool shouldBePlayedOnce = true;
    protected private bool hasBeenPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEvent(int eventId = 0)
    {
        base.OnTriggerEvent(eventId);

        if (audioSource != null && !audioSource.isPlaying)
        {
            if (shouldBePlayedOnce && !hasBeenPlayed)
            {
                audioSource.Play();
                hasBeenPlayed = true;
            }
            else if (!shouldBePlayedOnce)
            {
                audioSource.Play();
            }
        } 
    }
}
