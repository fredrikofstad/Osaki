using UnityEngine;

public class DanceZone : MonoBehaviour
{
    private Player character;
    private Transform textMeshTransform;
    private MeshRenderer textRender;
    private bool isDancing = false;
    private bool canPerform = true;
    private bool showText = true;
 
    private void Start()
    {
        textMeshTransform = GetComponentInChildren<RectTransform>();
        textRender = GetComponentInChildren<MeshRenderer>();
        character = GameManager.instance.playerScript;
    }



    private void OnTriggerStay()
    {
        if (!isDancing && canPerform)
        {
            ShowText();
        }
        else
        {
            ShowText(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && canPerform) //ugly change later lol
        {
            if (!isDancing)
            {
                character.Dance();
                isDancing = true;
                canPerform = false;
                Invoke("Delay", 3f);
            }
            else
            {
                character.Dance(false);
                isDancing = false;
                canPerform = false;
                Invoke("Delay", 1f);
            }
        }
    }
    private void ShowText(bool show = true)
    {
        if (show)
        {
            textRender.enabled = true;
            showText = true;
        }
        else
        {
            textRender.enabled = false;
            showText = false;
        }
    }
    private void OnTriggerExit()
    {
        ShowText(false);
    }
    private void Delay()
    {
        canPerform = true;
    }
    void Update()
    {
        if (showText)
            textMeshTransform.rotation = Camera.allCameras[0].transform.rotation;
    }
}
