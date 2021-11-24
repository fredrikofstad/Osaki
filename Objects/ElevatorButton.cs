using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interact
{
    public MeshRenderer lightUp;
    public Elevator elevator;
    public int floor;

    private AudioSource sound;

    protected override void Setup()
    {
        elevator.OpenDoors += DisableLights;
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (canPerform)
            {
                ShowText(true, "Press [E] to call elevator");
                if (InputManager.Interact())
                {
                    elevator.ButtonPressed(floor);
                    lightUp.enabled = true;
                    canPerform = false;
                    sound.Play();
                }
            }
            else
            {
                ShowText(false);
            }
        }
    }
    private void OnTriggerExit()
    {
        ShowText(false);
    }

    private void DisableLights()
    {
        lightUp.enabled = false;
        canPerform = true;
    }

}
