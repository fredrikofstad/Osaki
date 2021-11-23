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
        if(!GameManager.instance.so.friends.iroha)
            StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {
        GameManager.instance.so.cafe = true;
        GameManager.instance.so.friends.iroha = true;
        GameManager.instance.so.friendCount++;
        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Study at cafe: Task Complete!", 6f);

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText($"Meet my Friends: {GameManager.instance.so.friendCount}/{GameManager.maxFriends}", 6f);
    }

    private void OnDisable()
    {
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
