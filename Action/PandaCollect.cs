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
        pandaLife,
        pandaStation
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
                ShowText(true,"!",5);
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
        GameManager.instance.DisplayText($"[{GameManager.instance.so.pandaCount}/{GameManager.maxPanda}] Pandas Found!", 6f);
        sound.Play();
    }


}
