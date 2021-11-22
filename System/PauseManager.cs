using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseManager : MonoBehaviour
{

    //should make gameManager to control these things
    public delegate void PauseHandler();
    public event PauseHandler Paused;
    public event PauseHandler Resumed;


    public bool isPaused; //conisder making a static reference to the class and this variable
    //in that case remember to change cameracontroller checking for pause
    public Canvas canvas;
    public GameObject phone;
    private iPhoneAni phoneAni;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public bool pauseReady;
    private void Awake()
    {
        pauseReady = true;
        canvas.enabled = false;
        originalPosition = phone.transform.position;
        originalRotation = phone.transform.rotation;

        phoneAni = phone.GetComponent<iPhoneAni>();
        
    }

    private bool PauseKey()
    {
        if (!GameManager.instance.touchControls) //uff
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        if (PauseKey() && !GameManager.instance.inCutscene)
        {
            PauseGame();
            
        }
    }

    public void PauseGame()
    {
        if (pauseReady)
        {
            pauseReady = false;
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0f;
                canvas.enabled = true;
                Paused.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                canvas.enabled = false;
                phone.transform.position = originalPosition;
                phone.transform.rotation = originalRotation;
                pauseReady = true;
                Resumed.Invoke();

            }
        }
       
    }
}
