using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public MeshRenderer lightUp;
    public Elevator elevator;
    public int floor;

    private void Start()
    {
        elevator.OpenDoors += DisableLights;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (InputManager.Interact())
            {
                elevator.ButtonPressed(floor);
                lightUp.enabled = true;
            }
        }
    }
    private void DisableLights()
    {
        lightUp.enabled = false;
    }

}
