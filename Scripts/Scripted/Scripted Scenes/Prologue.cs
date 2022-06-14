using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Prologue : ScriptedScene
{
    [Header("Animator")]
    [SerializeField] Animator playerAnimator;

    [Header("Scripts")]
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWakeUpSequence(BaseEventData eventData)
    {
        if (player.playerControls != null && player.mouseRotate != null)
        {
            player.playerControls.LockControls();
            player.mouseRotate.LockCursor();
        }
    }

    public void PlayPostWakeUpSequence()
    {
        if (player.playerControls != null && player.mouseRotate != null)
        {
            player.playerControls.LockControls();
            player.mouseRotate.UnlockCursor(new Vector2(0, 0));
        }
    }

    public void PlayGetUpSequence()
    {
        if (player.playerControls != null && player.mouseRotate != null)
        {
            player.playerControls.LockControls();
            player.mouseRotate.UnlockCursor(new Vector2(0, 0), true);
        }

        if (playerAnimator != null)
        {
            Debug.Log("PlayGetUpSequence");
            
            playerAnimator.Play("Base Layer.Wake Up", 0, 0);
        }
    }
}
