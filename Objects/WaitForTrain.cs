using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTrain : MonoBehaviour
{
    public Train train;
    private List<GameObject> waiters = new List<GameObject>();
    private BoxCollider[] child;

    private void Start()
    {
        child = GetComponentsInChildren<BoxCollider>();
        train.ReadyToBoard += OnDoorsOpen;
        //train.ReadyToDisembark +=OnDoorsClose;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            waiters.Add(other.gameObject);
            other.GetComponent<NPCMovement>().Wait();
        }     

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            waiters.Remove(other.gameObject);
        }
        
    }

    public void OnDoorsOpen()
    {
        foreach(GameObject npc in waiters)
        {
            npc.GetComponent<NPCMovement>().Resume();
        }
    }

}
