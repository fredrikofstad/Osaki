using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDoors : MonoBehaviour
{
    private Transform[] doors;
    public Train train;

    private void Start()
    {

        doors = GetComponentsInChildren<Transform>();
        train.ReadyToBoard += Open;
        train.ReadyToDisembark += Close;
    }

    public void Open()
    {
        LeanTween.moveLocalX(doors[1].gameObject, 0.12f, 1f);
        LeanTween.moveLocalX(doors[2].gameObject, 0.12f, 1f).setOnComplete(FinishOpen);
    }
    private void FinishOpen()
    {
        LeanTween.moveLocalY(doors[1].gameObject, 2f, 1f);
        LeanTween.moveLocalY(doors[2].gameObject, -1f, 1f);
    }
    public void Close()
    {
        LeanTween.moveLocalY(doors[1].gameObject, 1f, 1f);
        LeanTween.moveLocalY(doors[2].gameObject, 0f, 1f).setOnComplete(FinishClose);
    }
    private void FinishClose()
    {
        LeanTween.moveLocalX(doors[1].gameObject, 0f, 1f);
        LeanTween.moveLocalX(doors[2].gameObject, 0f, 1f);
    }



}
