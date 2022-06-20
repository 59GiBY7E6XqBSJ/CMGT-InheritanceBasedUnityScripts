using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	protected private float verticalVelocity;
	protected private float groundedTimer;

	// The character controller component attached to the player.
	protected private CharacterController cc;

	[Header("Player")]
	[SerializeField] Player player;

	[Header("Movement")]
	[SerializeField] bool invertControls = false;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
		cc = GetComponent<CharacterController>();
    }

	// Update is called once per frame
	void Update()
    {
		// Component dependent actions //
        
        if (player != null)
        {
			if (player.canMove)
			{
				bool groundedPlayer = cc.isGrounded;
        		if (groundedPlayer)
        		{
        		    groundedTimer = 0.2f;
        		}
        		if (groundedTimer > 0)
        		{
        		    groundedTimer -= Time.deltaTime;
        		}

        		if (groundedPlayer && verticalVelocity < 0)
        		{
        		    verticalVelocity = 0f;
        		}

        		verticalVelocity -= gravityValue * Time.deltaTime;

				float x, z;
				x = Input.GetAxis("Horizontal");
				z = Input.GetAxis("Vertical");

				if (invertControls)
				{
					x = -x;
					z = -z;
				}

				Vector3 move = (gameObject.transform.right * x + gameObject.transform.forward * z);		
				move = Camera.main.transform.TransformDirection(move);
        		move *= playerSpeed;

        		if (Input.GetButtonDown("Jump"))
        		{
        		    if (groundedTimer > 0)
        		    {
        		        groundedTimer = 0;

        		        verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue);
        		    }
        		}

        		move.y = verticalVelocity;

        		cc.Move(move * Time.deltaTime);
			}
		}
		else 
		{
			Debug.Log("<color=red>Error: </color>Player is not set in the PlayerControls script.");
		}
	}

	public void LockControls()
	{
		player.canMove = false;

		player.footsteps.isOnSurface = false;
		player.footsteps.StopAllSounds();
	}

	public void UnlockControls()
	{
		Animator anim = GetComponent<Animator>();
		if (anim != null)
		{
			anim.enabled = false;
		}

		player.canMove = true;

		player.footsteps.isOnSurface = true;
	}
}
