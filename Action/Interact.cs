using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interact : MonoBehaviour
{
    protected Transform textMeshTransform;
    protected MeshRenderer textRender;
    protected Player character;
    protected InteractText text;
    protected bool showText = true;
    protected bool canPerform = true;
    void Start()
    {
        textMeshTransform = GetComponentInChildren<RectTransform>();
        textRender = GetComponentInChildren<MeshRenderer>();
        character = GameManager.instance.playerScript;
        text = character.text;
        Setup();
        
    }
    protected bool IsInteracting()
    {
        return (InputManager.Interact() && canPerform);
    }
    protected virtual void Setup()
    {
        //override this for start call
    }

    protected virtual void ShowText(bool show = true, string newText = "!", int size = 3)
    {
        if (show)
        {
            text.ShowText(true);
            text.ChangeText(newText, size);
            showText = true;
        }
        else
        {
            text.ShowText(false);
            showText = false;
        }
    }
    
}
