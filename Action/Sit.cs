using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : Interact
{
    private bool isSitting = false;
    private void OnCollisionStay(Collision collision)
    {
        if (!isSitting && canPerform)
        {
            ShowText();
        }
        else
        {
            ShowText(false);
        }
        if (IsInteracting())
        {
            if (!isSitting)
            {
                character.SitDown(this.transform.position, this.transform.rotation);
                isSitting = true;
                canPerform = false;
                Invoke("Delay", 3f); //coroutine better?
            }
            else
            {
                character.StandUp();
                isSitting = false;
                canPerform = false;
                Invoke("Delay", 3f);
            }
        }
    }

    private void Delay()
    {
        canPerform = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        ShowText(false);
    }

}
