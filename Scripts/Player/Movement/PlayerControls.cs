using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	protected private Rigidbody rb;

	[Header("Player")]
	[SerializeField] Player player;

	[Header("Camera")]
	[SerializeField] Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update() 
	{
        
	}

	// Frame-rate independent FixedUpdate message for physics calculations.
	void FixedUpdate()
    {
		if (player.canMove)
		{
			Vector3 moveVector = (cameraTransform.right * Input.GetAxis("Horizontal") + cameraTransform.forward * Input.GetAxis("Vertical")) * player.movementSpeed * Time.deltaTime;

			// Move the player with lerp to smooth the movement out when not using kinematic rigidbody
			rb.MovePosition(Vector3.Lerp(rb.position, rb.position + moveVector * player.movementSpeed * Time.deltaTime, player.movementLerp));

			// Rotate the main player body along with the camera direction (Not sure atm)
			// playerTrimage.pngansform.eulerAngles = new Vector3(0, cameraTransform.rotation.eulerAngles.y, 0);

			// Jump
			if (Input.GetButtonDown("Jump") && IsGrounded()) {
				rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
			}
		}
	}

	bool IsGrounded() 
	{
		//return Physics.Raycast(transform.position, Vector3.down, 1.5f);
		float _distanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, Vector3.down, _distanceToTheGround + 0.1f);
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

		rb.isKinematic = false;
	}
}
