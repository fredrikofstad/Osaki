using UnityEngine;
using Cinemachine;

public class ElevatorCamera : MonoBehaviour
{
    private CameraSwitch cam;
    public CinemachineVirtualCamera newCam;

    private void Start()
    {
        cam = GameManager.instance.mainCamera.GetComponent<CameraSwitch>();
    }
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            cam.SwitchCamera(newCam);
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            cam.SwitchCamera(newCam);
        }
    }

}
