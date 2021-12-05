using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanari : MonoBehaviour
{
    private RPGTalkArea area;
    private RPGTalk talk;
    private bool kanari;

    void Start()
    {
        area = GetComponent<RPGTalkArea>();
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnEndTalk += OnEndTalk;
        UpdateBeliefs();
    }
    public void UpdateBeliefs() 
    {
        if (GameManager.instance.so.paint)
        {
            area.lineToStart = "paint_begin";
            area.lineToBreak = "paint_end";
        }
        else
        {
            area.lineToStart = "start";
            area.lineToBreak = "end";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            kanari = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            kanari = false;
    }
    private void OnEndTalk()
    {
        if (kanari && !GameManager.instance.so.friends.kanari && GameManager.instance.so.paint)
            StartCoroutine(TaskComplete());
    }
    IEnumerator TaskComplete()
    {
        GameManager.instance.so.friends.kanari = true;
        GameManager.instance.so.friendCount++;

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText($"Meet my Friends: {GameManager.instance.so.friendCount}/{GameManager.maxFriends}", 6f);
    }
    private void OnDisable()
    {
        talk.OnEndTalk -= OnEndTalk;
    }
}
