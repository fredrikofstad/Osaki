using System.Collections;
using UnityEngine;

public class Akane : Cutscene
{
    private RPGTalk rpgtalk;
    private int choice = 0;
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
        }
    }
    protected override void OnCutsceneEnd()
    {
        //if statement for progression
        StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Get some exercise: Task Complete!", 6f);

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText("Meet my Friends: 2/7", 6f);
    }

    private void OnDisable()
    {
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
