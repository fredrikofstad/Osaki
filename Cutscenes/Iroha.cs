using System.Collections;
using UnityEngine;

public class Iroha : Cutscene
{
    private RPGTalk rpgtalk;
    private int choice = 0;
    private string question;
    protected override void Setup()
    {
        rpgtalk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        rpgtalk.OnMadeChoice += OnMadeChoice;
        rpgtalk.OnEndTalk += OnEndTalk;
    }

    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
        question = questionID;

    }
    private void OnEndTalk()
    {
        if(choice == 0 && question == "Study")
        {
            PlayCutscene();
        }
        question = null;
    }
    protected override void OnCutsceneEnd()
    {
        //if statement for progression
        StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Go to cafe to study: Task Complete!", 6f);

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText("Meet my Friends: 5/7", 6f);
    }

    private void OnDisable()
    {
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
