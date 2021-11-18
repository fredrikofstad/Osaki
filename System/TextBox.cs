using UnityEngine;
using UnityEngine.UI;

public class TextBox
{
    public bool active;
    public GameObject go;
    public Text txt;
    public float duration;
    public float lastShown;

    public void Shown()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateText()
    {
        if (!active)
            return;
        if (Time.time - lastShown > duration)
            Hide();

    }
}
