using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;

public class EscalatorMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

	public float force = 10f;

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = (endPoint.position - startPoint.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(force * dir);
        }
        else if(other.gameObject.tag == "NPC")
        {
            Vector3 dir = (endPoint.position - startPoint.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(force * dir);
            //other.GetComponent<NPCMovement>().standing = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            other.GetComponent<NPCMovement>().Resume();
        }
    }


}
