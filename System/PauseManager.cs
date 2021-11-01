using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.inCutscene)
        {
            if (pauseReady)
            {
                pauseReady = false;
                isPaused = !isPaused;
                PauseGame();
            }
            
        }
    }

    void PauseGame()
    {
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
