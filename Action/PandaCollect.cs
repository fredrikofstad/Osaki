using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaCollect : Interact
{
    AudioSource sound;
    public enum PandaName
    {
        pandaRoom,
        pandaOsaki,
        pandaBar,
        pandaStarbucks,
        pandaLife
    }
    public PandaName panda;
    protected override void Setup()
    {
        sound = gameObject.GetComponent<AudioSource>();
        ShowText(false);
        if (GameManager.instance.so.pandas[(int)panda])
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canPerform)
            {
                ShowText();
            }
            else
            {
                ShowText(false);
            }
            if (IsInteracting())
            {
                CollectPanda();
                canPerform = false;
                ShowText(false);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        ShowText(false);
    }
    private void CollectPanda()
    {
        GameManager.instance.so.pandas[(int)panda] = true;
        GameManager.instance.so.pandaCount++;
        string msg = "[" + GameManager.instance.so.pandaCount + "/6] Pandas Found!";
        GameManager.instance.DisplayText(msg, 6f);
        sound.Play();
        PlayerPrefs.SetInt("unlocked", 2);
    }


}
