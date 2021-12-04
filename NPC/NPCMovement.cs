using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public int rotationSpeed = 120;
    public float stopDistance = 0.01f;

    public Vector3 destination;
    public Vector3 nextDestination;
    public bool reachedDestination;
    public bool standing;
    private Animator anim;
    public bool random;
    private void Start()
    {
        movementSpeed = movementSpeed + Random.Range(-0.3f, 0.3f);
        destination = transform.position;
        reachedDestination = false;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (standing)
            return;
        if (transform.position == destination)
        {
            reachedDestination = true;
        }
        else
        {
            if (anim != null)
                anim.SetBool("isStanding", false);
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;

                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }
        }
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }

    public void Wait()
    {
        standing = true;
        anim.SetBool("isStanding", true);
    }
    public void Resume()
    {
        standing = false;
        anim.SetBool("isStanding", false);

    }
}
