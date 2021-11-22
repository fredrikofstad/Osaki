using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public static class InputManager
{
	public static bool Iteract()
	{
        if (GameManager.instance.touchControls)
        {
            return CrossPlatformInputManager.GetButton("Interact");
        }
        else
        {
            return Input.GetKey("Interact");
        }
	}

}
