using UnityEngine;

public class Mariya : Cutscene
{
    private RPGTalk rpgtalk;
    private int choice = 5;
    private Quaternion originalRot;
    protected override void Setup()
    {
        rpgtalk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        rpgtalk.OnMadeChoice += OnMadeChoice;
        rpgtalk.OnEndTalk += OnEndTalk;
        originalRot = transform.rotation;
        GameManager.instance.PauseMusic();
    }

    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
    }
    private void OnEndTalk()
    {
        if(choice == 0)
        {
            transform.rotation = originalRot;
            PlayCutscene();
            choice = 5;
        }
    }
    protected override void OnCutsceneEnd()
    {
        //if statement for progression
        Invoke("TaskComplete", 1f);
    }

    private void TaskComplete()
    {
        GameManager.instance.DisplayText("Meet my Friends: 1/7", 6f);
    }

    private void OnDisable()
    {
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
