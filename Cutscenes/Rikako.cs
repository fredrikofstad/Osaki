using System.Collections;
using UnityEngine;

public class Rikako : MonoBehaviour
{
    private RPGTalkArea area;
    private RPGTalk talk;
    private int choice = 5;

    void Start()
    {
        area = GetComponent<RPGTalkArea>();
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnEndTalk += OnEndTalk;
        talk.OnMadeChoice += OnMadeChoice;
    }
    public void UpdateBeliefs()
    {
        if (GameManager.instance.so.friends.rikako)
        {
            area.lineToStart = "finish_begin";
            area.lineToBreak = "finish_end";
        }
        else
        {
            area.lineToStart = "start";
            area.lineToBreak = "end";
        }
    }

    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
    }

    private void OnEndTalk()
    {
        if (!GameManager.instance.so.friends.rikako && choice == 0)
            StartCoroutine(TaskComplete());
        choice = 5;
            
    }
    IEnumerator TaskComplete()
    {
        GameManager.instance.so.friends.rikako = true;
        GameManager.instance.so.friendCount++;

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText($"Meet my Friends: {GameManager.instance.so.friendCount}/{GameManager.maxFriends}", 6f);
    }
    private void OnDisable()
    {
        talk.OnEndTalk -= OnEndTalk;
        talk.OnMadeChoice += OnMadeChoice;
    }
}
