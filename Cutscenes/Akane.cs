using System.Collections;
using UnityEngine;

public class Akane : Cutscene
{
    private RPGTalk rpgtalk;
    private int choice = 5;
    protected override void Setup()
    {
        rpgtalk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        rpgtalk.OnMadeChoice += OnMadeChoice;
        rpgtalk.OnEndTalk += OnEndTalk;
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
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
