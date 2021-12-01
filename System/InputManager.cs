using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public static class InputManager
{
	public static bool Interact()
	{
        if (GameManager.instance.touchControls)
        {
            return CrossPlatformInputManager.GetButtonUp("Interact");
        }
        else
        {
            return Input.GetButtonUp("Interact");
        }
	}

}
