using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : Interact
{
    public string destination;
    public Vector3 newLocation;
    public Vector3 newRotation;
    public string msg = "";
    private Animator anim;

    protected override void Setup()
    {
        anim = GetComponentInParent<Animator>();
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canPerform)
            {
                ShowText(true, "Press [E] to Open");
            }
            else
            {
                ShowText(false);
            }
            if (IsInteracting())
            {
                character.OpenDoor(this.transform.position, this.transform.rotation);
                canPerform = false;
                ShowText(false);
                anim.SetTrigger("onOpen");
                StartCoroutine(NewScene());
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        ShowText(false);
    }

    IEnumerator NewScene()
    {
        yield return new WaitForSeconds(2.4f);
        GameManager.instance.transition.FadeIn(msg);
        yield return new WaitForSeconds(0.6f);
        GameManager.instance.GiveLocation(newLocation, newRotation);
        SceneManager.LoadScene(sceneName: destination);
    }

}
