using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    //should combine with train door lol
    public Transform[] doors;
    public float[] originalPos = {0f,0f,0f};
    private float[] destination = {0f, 0f, 3.5f};
    private float duration = 1f;
    private bool open = false;
    public float doorsOpenDuration = 15f;
    public float waitDuration = 1f;
    public Elevator elevator;
    private Coroutine close;

    private void Start()
    {
        doors = GetComponentsInChildren<Transform>();
        for (int i = 0; i < doors.Length; i++)
        {
            originalPos[i] = doors[i].localPosition.x;
        }
        elevator.OpenDoors += Open;
        elevator.CloseDoors += Close;
    }

    public void Open()
    {
        if (!open)
        {
            StartCoroutine(OpenDoorsTimer());
            open = true;
            
        }
        
    }
    public void Close()
    {
        if (open)
        {
            StartCoroutine(CloseDoorsTimer());
            if(close != null)
                StopCoroutine(close);
            open = false;
        }
    }
    IEnumerator OpenDoorsTimer()
    {
        yield return new WaitForSeconds(waitDuration);
        LeanTween.moveLocalX(doors[1].gameObject, destination[1], duration);
        LeanTween.moveLocalX(doors[2].gameObject, destination[2], duration);
        close = StartCoroutine(CloseAgain());
    }
    IEnumerator CloseDoorsTimer()
    {
        yield return new WaitForSeconds(waitDuration);
        LeanTween.moveLocalX(doors[1].gameObject, originalPos[1], duration);
        LeanTween.moveLocalX(doors[2].gameObject, originalPos[2], duration);
    }
    IEnumerator CloseAgain()
    {
        yield return new WaitForSeconds(doorsOpenDuration);
        Close();
        elevator.trapped = true;
    }

}
