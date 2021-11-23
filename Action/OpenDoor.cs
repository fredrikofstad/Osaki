using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : Interact
{
    public string destination;
    public Vector3 newLocation;
    public Vector3 newRotation;
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
                Invoke("NewScene", 3f);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        ShowText(false);
    }

    private void NewScene()
    {
        GameManager.instance.GiveLocation(newLocation, newRotation);
        SceneManager.LoadScene(sceneName: destination);
    }
    
}
