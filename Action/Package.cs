using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : Interact
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject contents;
    private bool opened;


    private void OnTriggerStay(Collider other)
    {
        if (opened)
            return;
        if (other.gameObject.tag == "Player")
        {
            if (canPerform)
            {
                ShowText(true, "Press [E] to Open");
            }
            else
            {
                ShowText(false);
            }
            if (IsInteracting())
            {
                canPerform = false;
                ShowText(false);
                anim.SetTrigger("open");
                contents.SetActive(true);
                contents.GetComponent<BoxCollider>().enabled = false;
                Invoke("EmployContents",1f);
                opened = true;
            }
        }
    }
    private void EmployContents()
    {
        contents.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ShowText(false);
    }

}