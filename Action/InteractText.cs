using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Camera.allCameras[0].transform.rotation;
    }
    public void ShowText(bool show = true)
    {
        if (show)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ChangeText(string newText = "Press [E] to talk", int size = 3)
    {
        GetComponent<TextMeshPro>().text = newText;
        GetComponent<TextMeshPro>().fontSize = size;
    }
}
