using System;
using UnityEngine;

public class iPhoneAni : MonoBehaviour
{
    public GameObject screen;
    private CanvasGroup[] appList;
    public GameObject musicList;

    public enum Apps:int
    {
        Homescreen,
        Instagram,
        Notes
    }

    private void Start()
    {
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
        LeanTween.alphaCanvas(appList[(int)Apps.Homescreen], 1f, 0.3f).setIgnoreTimeScale(true).setOnComplete(Ready);
        appList[(int)Apps.Homescreen].blocksRaycasts = true;
    }
    public void HideApps()
    {
        foreach(CanvasGroup app in appList)
        {
            app.alpha = 0;
            app.blocksRaycasts = false;
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
        appList[app].alpha = 1;
        appList[app].blocksRaycasts = true; //consider making gameobject array to deactivate instead
    }

    private void OnDisable()
    {
        GameManager.instance.pause.Resumed -= HideApps;
        GameManager.instance.pause.Paused -= OnPause;
    }

}
