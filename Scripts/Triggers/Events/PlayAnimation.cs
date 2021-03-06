using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : Trigger
{
    [Header("Animation")]
    [SerializeField] Animator animatorToPlay;
    [SerializeField] string animationToPlay = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEvent(int eventId = 0)
    {
        base.OnTriggerEvent(eventId);

        if (animatorToPlay != null)
        {
            animatorToPlay.Play(animationToPlay, 0, 0);
        }
    }
}
