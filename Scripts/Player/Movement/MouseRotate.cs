using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
	private protected bool isPaused = false;

    private protected Vector2 rotation = new Vector2(0, -90);

	[Header("Player")]
	[SerializeField] Player player;

    // Update is called once per frame
    void Update()
    {
		Cursor.lockState = CursorLockMode.Locked;

    	if (player.canRotate && !isPaused) 
    	{
    		rotation.y += Input.GetAxis("Mouse X");
			rotation.x += -Input.GetAxis("Mouse Y");
    		rotation.x = Mathf.Clamp(rotation.x, -25f, 25f);

			// Camera will snap into odd position by default, this can be fixed by using Unity's cursor lock
    		transform.localEulerAngles = (Vector2)rotation * player.rotationSpeed;
    	}
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
