using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private RPGTalkArea area;
    private RPGTalk talk;
    private Clothes player;
    private int choice = 0;
    private string question;

    void Start()
    {
        area = GetComponent<RPGTalkArea>();
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        player = GameManager.instance.player.GetComponent<Clothes>();
        talk.OnMadeChoice += OnMadeChoice;
        talk.OnEndTalk += OnEndTalk;
        area.lineToStart = "both_begin";
        area.lineToBreak = "both_end";
    }
    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
        question = questionID;
    }
    private void OnEndTalk()
    {
        if (choice == 1)
        {
            if (question == "clothes2")
                player.ChangeClothes(2);
            else
                player.ChangeClothes(1);
        }
        else if(choice == 2)
        {
            player.ChangeClothes(2);
        }
        else
        {
            player.ChangeClothes(0);
        }

        //reset
        choice = 0;
        question = null;
    }
    private void OnDisable()
    {
        talk.OnMadeChoice -= OnMadeChoice;
        talk.OnEndTalk -= OnEndTalk;
    }

}
