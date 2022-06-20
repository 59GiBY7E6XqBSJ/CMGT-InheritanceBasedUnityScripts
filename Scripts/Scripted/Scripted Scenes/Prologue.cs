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
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void PlayWakeUpSequence(BaseEventData eventData)
    {
        // Component dependent actions //
        
        if (player != null)
        {
            // Lock controls
            if (player.playerControls != null && player.mouseRotate != null)
            {
                player.playerControls.LockControls();
                player.mouseRotate.LockCursor();
            }
        }
    }

    public void PlayPostWakeUpSequence()
    {
        // Component dependent actions //
        
        if (player != null)
        {
            // Unlock mouse controls
            if (player.playerControls != null && player.mouseRotate != null)
            {
                player.playerControls.LockControls();
                player.mouseRotate.UnlockCursor(new Vector2(0, 0));
            }
        }
    }

    public void PlayGetUpSequence()
    {
        // Component dependent actions //
        
        if (player != null)
        {
            // Unlock mouse controls
            if (player.playerControls != null && player.mouseRotate != null)
            {
                player.playerControls.LockControls();
                player.mouseRotate.UnlockCursor(new Vector2(0, 0), true);
            }

            // Play the initial waking up animation after the player has pressed the wake up tooltip
            if (playerAnimator != null)
            {
                playerAnimator.Play("Base Layer.Wake Up", 0, 0);
            }
        }
    }
}
