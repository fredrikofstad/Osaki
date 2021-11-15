using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akane : MonoBehaviour
{
    public RPGTalk rpgtalk;
    private int choice = 0;
    private int cMade = 0;
    void Start()
    {
        rpgtalk.OnMadeChoice += OnMadeChoice;
        rpgtalk.OnEndTalk += OnEndTalk;
    }



    void OnMadeChoice(string questionID, int choiceID)
    {

        Debug.Log(questionID + " option: " + choiceID + " how many made " + cMade); ;
        choice = choiceID;
        cMade++;
    }
    void OnEndTalk()
    {
        Debug.Log(choice);
        if(choice == 0)
        {
            Exercise();
        }
        else
        {
            Debug.Log("no exercise");
        }
    }
    void Exercise()
    {
        Debug.Log("LETSA GOO!");
    }
    private void OnDisable()
    {
        rpgtalk.OnMadeChoice -= OnMadeChoice;
        rpgtalk.OnEndTalk -= OnEndTalk;
    }
}
