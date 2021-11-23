using UnityEngine;

public class DanceZone : Interact
{
    private bool isDancing = false;

    protected override void Setup()
    {
        textMeshTransform = GetComponentInChildren<RectTransform>();
        textRender = GetComponentInChildren<MeshRenderer>();
        character = GameManager.instance.playerScript;
    }



    private void OnTriggerStay()
    {
        if (!isDancing && canPerform)
        {
            ShowText(true, "Press [E] to Dance");
        }
        else
        {
            ShowText(false);
        }
        if (IsInteracting())
        {
            if (!isDancing)
            {
                character.Dance();
                isDancing = true;
                canPerform = false;
                Invoke("Delay", 3f);
            }
            else
            {
                character.Dance(false);
                isDancing = false;
                canPerform = false;
                Invoke("Delay", 1f);
            }
        }
    }
    private void OnTriggerExit()
    {
        ShowText(false);
    }
    private void Delay()
    {
        canPerform = true;
    }
}
