using UnityEngine;
using Cinemachine;
using System.Collections;

public class PlayerCam : MonoBehaviour
{
    CinemachineVirtualCamera thisCamera;
    Cinemachine3rdPersonFollow follow;
    PauseManager pause;
    Transform cameraController;
    private bool paused;
    void Start()
    {
        thisCamera = GetComponent<CinemachineVirtualCamera>();
        thisCamera.Follow = GameManager.instance.playerScript.cameraTarget;
        follow = thisCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        pause = GameManager.instance.pause;
        cameraController = GameManager.instance.playerScript.cameraControl;


        pause.Paused += OnPause;
        pause.Resumed += OnResume;
    }

    private void Update()
    {
        if (paused)
        {
            cameraController.Rotate(0, Time.unscaledDeltaTime, 0);
        }
    }

    private void OnPause()
    {
        paused = true;
        StartCoroutine(ChangeSide(1f, 0.5f, 2f));
    }
    private void OnResume()
    {
        paused = false;
        StartCoroutine(ChangeSide(0.5f, 2f, 2f));
    }

    IEnumerator ChangeSide(float sideValue, float distance, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            float startSideValue = follow.CameraSide;
            float startDistance = follow.CameraDistance;
            follow.CameraSide = Mathf.Lerp(startSideValue, sideValue, time / duration);
            follow.CameraDistance = Mathf.Lerp(startDistance, distance, time / duration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        follow.CameraSide = sideValue;
        follow.CameraDistance = distance;
    }
    private void OnDisable()
    {
        pause.Paused -= OnPause;
        pause.Resumed -= OnResume;
    }


}
