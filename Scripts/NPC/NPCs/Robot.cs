using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : NPC
{
    private protected Animator animator;

    [Header("Animators")]
    [SerializeField] Animator roomAnimator;
    [SerializeField] Animator roomAnimator2;

    [Header("Triggers")]
    [SerializeField] GameObject doorTrigger;
    [SerializeField] GameObject doorTrigger2;
    [SerializeField] GameObject doorTrigger3;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void PlayWelcomeSequence()
    {
        // Component independent actions //

        // Play the animation of robot entering the room
        if (animator != null)
        {
            animator.Play("Moving.MoveInRoom", 1, 0);
        }

        // Component dependent actions //
        
        if (player != null)
        {
            player.canMove = false;
            player.footsteps.isOnSurface = false;

            if (player.hud != null)
            {
                // Show the transcript window with the welcome message 5 seconds after the sequence start
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.SetTranscript("Robot", "Hello, look who's finlly awake. You better hurry up if you don't want to miss your ship to Earth. Unless you want to be stuck here for another 2 years.");
                }, 5));

                // Hide the transcript window after 16 seconds
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.FadeoutTranscript();
                }, 16));

                // Show the transcript window with the follow me message 17 seconds after the sequence start
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.SetTranscript("Robot", "Follow me.");
                }, 17));

                // Hide the transcript window after 21 seconds
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.FadeoutTranscript();
                }, 21));
            }
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Player is not set in the Robot script.");
        }

        // Open the door into the room for robot to walk in
        if (roomAnimator != null)
        {
            roomAnimator.Play("Base Layer.Door", 0, 0);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Room Animator 1 is not set in the Robot script.");
        }

        // De-activate the trigger so that this scripted sequence can be repeated.
        if (doorTrigger != null)
        {
            doorTrigger.SetActive(false);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Door Trigger 1 is not set in the Robot script.");
        }
    }

    public void PlayFollowMeSequence()
    {
        // Component dependent actions //

        if (player != null)
        {
            player.canMove = true;
            player.footsteps.isOnSurface = true;
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Player is not set in the Robot script.");
        }
    }

    public void PlayFollowMeSequence2()
    {
        // Component independent actions //

        // Play the animation of robot moving towards the first door
        if (animator != null)
        {
            animator.Play("Moving.MoveAfterTrigger1", 1, 0);
        }

        // Component dependent actions //

        if (player != null)
        {
            player.canMove = true;
            player.footsteps.isOnSurface = true;
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Player is not set in the Robot script.");
        }

        // Close the door into the room after player has reached the second door
        if (roomAnimator != null)
        {
            roomAnimator.Play("Base Layer.DoorClose", 0, 0);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Room Animator 1 is not set in the Robot script.");
        }

        // Open the door into the second room for robot and player to walk in
        if (roomAnimator2 != null)
        {
            roomAnimator2.Play("Base Layer.Door", 0, 0);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Room Animator 2 is not set in the Robot script.");
        }

        // De-activate the second trigger so that this scripted sequence can be repeated.
        if (doorTrigger2 != null)
        {
            doorTrigger2.SetActive(false);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Door Trigger 2 is not set in the Robot script.");
        }
    }

    public void PlayFollowMeSequence3()
    {
        // Component independent actions //

        // Play the animation of robot moving into the main hall
        if (animator != null)
        {
            animator.Play("Moving.MoveAfterTrigger2", 1, 0);
        }

        // Component dependent actions //

        if (player != null)
        {
            player.canMove = true;
            player.footsteps.isOnSurface = true;

            if (player.hud != null)
            {
                // Show the transcript window with the last message 2 seconds after the sequence start
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.SetTranscript("Robot", "This is the main hall. You should be able to find your way into departures hall from here. Unfortunately, I won't be able to go with you any further. Good luck, don't forget to check the time your ship is leaving and the departure gate.");
                }, 2));

                // Hide the transcript window after 21 seconds
                StartCoroutine(CallLaterScript.WaitSeconds(() =>
                {
                    player.hud.FadeoutTranscript();
                }, 21));
            }
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Player is not set in the Robot script.");
        }

        // Close the door into the second room
        if (roomAnimator2 != null)
        {
            roomAnimator2.Play("Base Layer.DoorClose", 0, 0);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Room Animator 2 is not set in the Robot script.");
        }

        // De-activate the third trigger so that this scripted sequence can be repeated.
        if (doorTrigger3 != null)
        {
            doorTrigger3.SetActive(false);
        }
        else 
        {
            Debug.Log("<color=red>Error: </color>Door Trigger 3 is not set in the Robot script.");
        }
    }
}
