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
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWelcomeSequence()
    {
        player.canMove = false;
        player.footsteps.isOnSurface = false;

        if (roomAnimator != null)
        {
            roomAnimator.Play("Base Layer.Door", 0, 0);
        }

        if (animator != null)
        {
            animator.Play("Moving.MoveInRoom", 1, 0);
        }

        if (doorTrigger != null)
        {
            doorTrigger.SetActive(false);
        }
    }

    public void PlayFollowMeSequence()
    {
        player.canMove = true;
        player.footsteps.isOnSurface = true;
    }

    public void PlayFollowMeSequence2()
    {
        player.canMove = true;
        player.footsteps.isOnSurface = true;

        if (roomAnimator2 != null)
        {
            roomAnimator2.Play("Base Layer.Door", 0, 0);
        }

        if (animator != null)
        {
            animator.Play("Moving.MoveAfterTrigger1", 1, 0);
        }

        if (doorTrigger2 != null)
        {
            doorTrigger2.SetActive(false);
        }
    }

    public void PlayFollowMeSequence3()
    {
        player.canMove = true;
        player.footsteps.isOnSurface = true;

        if (roomAnimator2 != null)
        {
            roomAnimator2.Play("Base Layer.DoorClose", 0, 0);
        }

        if (animator != null)
        {
            animator.Play("Moving.MoveAfterTrigger2", 1, 0);
        }

        if (doorTrigger3 != null)
        {
            doorTrigger3.SetActive(false);
        }
    }
}
