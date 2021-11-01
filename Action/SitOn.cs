using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOn : MonoBehaviour
{
    public GameObject character;
    public Animator anim;
    public bool isWalkingTowards = false;
    public bool sittingOn = false;

    void OnMouseDown()
    {
        if (!sittingOn)
        {
            anim.SetTrigger("isWalking");
            isWalkingTowards = true;
            //character.Pause();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isWalkingTowards)
        {
            Vector3 targetDir;
            targetDir = new Vector3(transform.position.x - character.transform.position.x,
                0f, transform.position.z);
            Quaternion rot = Quaternion.LookRotation(targetDir);
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation, rot, 0.05f);
            character.transform.Translate(Vector3.forward * 0.1f);

            if(Vector3.Distance(character.transform.position, this.transform.position) < 0.6)
            {
                anim.SetTrigger("isSitting");
                //no slerp, consider slerping
                character.transform.rotation = this.transform.rotation;
                sittingOn = true;
                isWalkingTowards = false;
            }
        }
    }
}
