using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public delegate void ElevatorHandler();
    public event ElevatorHandler OpenDoors;
    public event ElevatorHandler CloseDoors;
    
    public bool trapped = false;

    [SerializeField] private int currentFloor = 1;
    [SerializeField] private bool inProgress = false;

    private AudioSource sound;

    public float duration = 10f;
    public float waitDuration = 2f;
    private float[] destination = {1, 0.14f, 1, 1, 1, 1, 1, 21.75f, 1};
    private GameObject passenger;

    private void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !inProgress)
        {
            inProgress = true;
            //other.transform.parent = this.transform;
            CloseDoors.Invoke();
            StartCoroutine(Wait());
            passenger = other.gameObject;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !inProgress && trapped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenDoors.Invoke();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //other.transform.parent = null;
        trapped = false;
        passenger = null;
    }
    public void ButtonPressed(int floor)
    {
        if (inProgress)
            return;
        if(currentFloor != floor)
        {
            GoToFloor(floor);
        } 
        else
        {
            Arrived();
        }
    }
    public void GoToFloor(int floor)
    {
        inProgress = true;
        LeanTween.moveLocalY(gameObject, destination[floor], duration).setOnComplete(Arrived);
        if (passenger != null)
        {
            //float difference =  destination[floor] - transform.position.y;
            LeanTween.moveLocalY(passenger, destination[floor], duration);
        }
        currentFloor = floor;
    }
    public void Arrived()
    {
        sound.Play();
        OpenDoors.Invoke();
        inProgress = false;
    }

    private void FloorDesicion()
    {
        // #scalable
        if (currentFloor == 7)
        {
            GoToFloor(1);
        }
        else
        {
            GoToFloor(7);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitDuration);
        FloorDesicion();
        
    }
}
