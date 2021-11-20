using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaCollect : Interact
{
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
        ShowText(false);
        if (GameManager.instance.so.pandas[(int)panda])
        {
            Debug.Log("deleted panda");
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(canPerform);
            if (canPerform)
            {
                ShowText();
            }
            else
            {
                ShowText(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && canPerform)
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
        string msg = "[" + GameManager.instance.so.pandaCount + "/5] Pandas Found!";
        GameManager.instance.DisplayText(msg, 6f);
    }

}
