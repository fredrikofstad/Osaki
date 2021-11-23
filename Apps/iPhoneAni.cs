using System;
using UnityEngine;

public class iPhoneAni : MonoBehaviour
{
    public GameObject screen;
    private CanvasGroup[] appList;
    public GameObject musicList;
    private GameObject eventSystem;


    public enum Apps:int
    {
        Homescreen,
        Instagram,
        Notes,
        Music,
        Settings,
        Photos
    }

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        appList = screen.GetComponentsInChildren<CanvasGroup>();

        GameManager.instance.pause.Resumed += HideApps;
        GameManager.instance.pause.Paused += OnPause;

        HideApps();

    }
    public void OnPause()
    {
        HideApps();
        LeanTween.rotateX(gameObject, 90, 1f).setIgnoreTimeScale(true);
        LeanTween.moveZ(gameObject, 0, 1f).setIgnoreTimeScale(true).setOnComplete(ShowApps);
    }
    void ShowApps()
    {
        appList[(int)Apps.Homescreen].gameObject.SetActive(true);
        appList[(int)Apps.Homescreen].alpha = 0;
        LeanTween.alphaCanvas(appList[(int)Apps.Homescreen], 1f, 0.3f).setIgnoreTimeScale(true).setOnComplete(Ready);
        appList[(int)Apps.Homescreen].blocksRaycasts = true;
    }
    public void HideApps()
    {
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        for (int i = 0; i < appList.Length; i++)
        {
            if(i == (int)Apps.Music)
            {
                appList[i].alpha = 0;
                appList[i].blocksRaycasts = false;
            }
            else
            {
                appList[i].gameObject.SetActive(false);
            }
            
        }
        musicList.SetActive(false);

    }
    void Ready()
    {
        GameManager.instance.pause.pauseReady = true; //sketchy?
    }
    public void LaunchApp(int app)
    {
        HideApps();
        if(app == (int)Apps.Music) //because I can't deactivate music app, then music bye bye
        {
            appList[app].alpha = 1;
            appList[app].blocksRaycasts = true;
        } else
        {
            appList[app].gameObject.SetActive(true);
        }
        
    }

    private void OnDisable()
    {
        GameManager.instance.pause.Resumed -= HideApps;
        GameManager.instance.pause.Paused -= OnPause;
    }

}
