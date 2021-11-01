using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour

{
    private CinemachineVirtualCamera playerCam;

    public void Start()
    {
        playerCam = GameManager.instance.playerCam;
    }
    public void SwitchCamera(CinemachineVirtualCamera second)
    {
        GameManager.instance.playerScript.ChangeCamera();

        if(playerCam.Priority > second.Priority)
        {
            playerCam.Priority = 0;
            second.Priority = 1;
        }
        else
        {
            playerCam.Priority = 1;
            second.Priority = 0;
        }
            
    }
}
