using System.Collections;
using UnityEngine;

public class Akane : Cutscene
{
    private RPGTalk talk;
    private RPGTalkArea area;
    private int choice = 5;
    protected override void Setup()
    {
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        area = GetComponent<RPGTalkArea>();
        talk.OnMadeChoice += OnMadeChoice;
        talk.OnEndTalk += OnEndTalk;
    }

    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
    }
    private void OnEndTalk()
    {
        if(choice == 0)
        {
            PlayCutscene();
            choice = 5;
        }
    }
    public void UpdateBeliefs()
    {
        if (GameManager.instance.so.friends.akane)
        {
            area.lineToStart = "finish_start";
            area.lineToBreak = "finish_end";
        }
        else
        {
            area.lineToStart = "start";
            area.lineToBreak = "end";
        }
    }
    protected override void OnCutsceneEnd()
    {
        if (!GameManager.instance.so.friends.akane)
            StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {
        GameManager.instance.so.exercise = true;
        GameManager.instance.so.friends.akane = true;
        GameManager.instance.so.friendCount++;

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Get some exercise: Task Complete!", 6f);

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText($"Meet my Friends: {GameManager.instance.so.friendCount}/{GameManager.maxFriends}", 6f);
    }

    private void OnDisable()
    {
        talk.OnMadeChoice -= OnMadeChoice;
        talk.OnEndTalk -= OnEndTalk;
    }
}
