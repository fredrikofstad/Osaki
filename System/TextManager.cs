using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject textContainer;
    [SerializeField]
    private GameObject textPrefab;
    private AudioSource sound;

    private List<TextBox> textList = new List<TextBox>();

    private void Awake()
    {
        textContainer = gameObject;
        sound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        foreach (TextBox txt in textList)
            txt.UpdateText();
    }

    public void Show(string msg, float duration)
    {
        TextBox textBox = getTextBox();
        sound.Play();

        textBox.txt.text = msg;
        textBox.duration = duration;

        textBox.Shown();
    }

    private TextBox getTextBox()
    {
        TextBox txt = textList.Find(t => t.active);

        if (txt == null)
        {
            txt = new TextBox();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            textList.Add(txt);
        }
        return txt;
    }
}
