using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
	private protected bool isPaused = false;

	// Offset the default rotation of the camera 
    private protected Vector2 rotation = new Vector2(0, -90);

	[Header("Player")]
	[SerializeField] Player player;

    // Update is called once per frame
    void Update()
    {
		// Component dependent actions //
        
        if (player != null)
        {
			// Camera will snap into odd position by default, this can be fixed by using Unity's cursor lock
			Cursor.lockState = CursorLockMode.Locked;

			// Only allow camera to rotate if player is not paused and is allowed to rotate 
    		if (player.canRotate && !isPaused) 
    		{
    			rotation.y += Input.GetAxis("Mouse X");
				rotation.x += -Input.GetAxis("Mouse Y");
    			rotation.x = Mathf.Clamp(rotation.x, -25f, 25f);

				transform.localEulerAngles = (Vector2)rotation * player.rotationSpeed;
    		}
		}
		else 
        {
            Debug.Log("<color=red>Error: </color>Player is not set in the MouseRotate script.");
        }
    }

	public Vector2 GetRotation()
	{
		return rotation;
	}

	public void LockCursor()
	{
		player.canRotate = false;
	}

	public void UnlockCursor()
	{
		player.canRotate = true;
	}

	public void UnlockCursor(Vector2 rotation, bool keepCurrentRotation = false)
	{
		if (!keepCurrentRotation)
			this.rotation = rotation;

		player.canRotate = true;
	}

	void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
