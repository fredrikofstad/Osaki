using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPaint : MonoBehaviour
{
    private RPGTalk talk;
    private bool paint;
    void Start()
    {
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnMadeChoice += OnMadeChoice;
        if(GameManager.instance.so.paint)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            paint = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            paint = true;
    }
    private void OnMadeChoice(string questionID, int choiceID)
    {
        if (choiceID == 0 && paint)
        {
            GameManager.instance.so.paint = true;
            Destroy(gameObject);
        }
    }
    private void OnDisable()
    {
        talk.OnMadeChoice -= OnMadeChoice;
    }
}
