using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    //should combine with train door lol
    public Transform[] doors;
    private float[] originalPos = { 0f, 0f, -3f };
    private float[] destination = { 0f, 3f, -6f };
    private float duration = 1f;
    private bool open = false;

    private void Start()
    {
        doors = GetComponentsInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Open();
    }
    private void OnTriggerExit(Collider other)
    {
        Close();
    }

    public void Open()
    {
        if (!open)
        {
            LeanTween.moveLocalX(doors[1].gameObject, destination[1], duration);
            LeanTween.moveLocalX(doors[2].gameObject, destination[2], duration);
            open = true;

        }

    }
    public void Close()
    {
        if (open)
        {
            LeanTween.moveLocalX(doors[1].gameObject, originalPos[1], duration);
            LeanTween.moveLocalX(doors[2].gameObject, originalPos[2], duration);
            open = false;
        }
    }

}
