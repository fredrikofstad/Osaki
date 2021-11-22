using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interact : MonoBehaviour
{
    protected Transform textMeshTransform;
    protected MeshRenderer textRender;
    protected Player character;
    protected bool showText = true;
    protected bool canPerform = true;
    void Start()
    {
        textMeshTransform = GetComponentInChildren<RectTransform>();
        textRender = GetComponentInChildren<MeshRenderer>();
        character = GameManager.instance.playerScript;
        Setup();
        
    }
    protected bool IsInteracting()
    {
        return (InputManager.Iteract() && canPerform); //ugly change later lol
    }
    protected virtual void Setup()
    {
        //override this for start call
    }
    protected virtual void Update()
    {
        if (showText)
            textMeshTransform.rotation = Camera.allCameras[0].transform.rotation;
    }

    protected virtual void ShowText(bool show = true)
    {
        if (show)
        {
            textRender.enabled = true;
            showText = true;
        }
        else
        {
            textRender.enabled = false;
            showText = false;
        }
    }
    
}
