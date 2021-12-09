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
    private bool closet;

    void Start()
    {
        area = GetComponent<RPGTalkArea>();
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        player = GameManager.instance.player.GetComponent<Clothes>();
        talk.OnMadeChoice += OnMadeChoice;
        talk.OnEndTalk += OnEndTalk;
        Unlocked();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            closet = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            closet = false;
    }
    private void Unlocked()
    {
        if(GameManager.instance.so.work && GameManager.instance.so.pandaCount >= GameManager.maxPanda)
        {
            area.lineToStart = "both_begin";
            area.lineToBreak = "both_end";
        } 
        else if(GameManager.instance.so.work && GameManager.instance.so.pandaCount < GameManager.maxPanda)
        {
            area.lineToStart = "work_begin";
            area.lineToBreak = "work_end";
        }
        else if (!GameManager.instance.so.work && GameManager.instance.so.pandaCount >= GameManager.maxPanda)
        {
            area.lineToStart = "panda_begin";
            area.lineToBreak = "panda_end";
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
        question = questionID;
    }
    private void OnEndTalk()
    {
        if (!closet)
            return;
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
        question = "";
    }
    private void OnDisable()
    {
        talk.OnMadeChoice -= OnMadeChoice;
        talk.OnEndTalk -= OnEndTalk;
    }

}
