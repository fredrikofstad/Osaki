using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGrocery : MonoBehaviour
{
    public enum Food
    {
        Tomato,
        Eggs,
        Juice,
        Sushi,
        Icecream
    }
    public Food food;

    private RPGTalk talk;
    private RPGTalkArea talk2;
    private Groceries player;
    public string foodItem;
    bool thisGrocery;
    void Start()
    {
        foodItem = System.Enum.GetName(typeof(Food), food);
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        player = GameManager.instance.player.GetComponent<Groceries>();
        talk.OnMadeChoice += OnMadeChoice;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            talk.variables[0].variableValue = foodItem;
            thisGrocery = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thisGrocery = false;
        }
    }
    private void OnMadeChoice(string questionID, int choiceID)
    {
        if (choiceID == 0 && thisGrocery)
        {
            Debug.Log("now!");
            player.ActivateFood((int)food);
            Destroy(gameObject);
        }
    }
    private void OnDisable()
    {
        talk.OnMadeChoice -= OnMadeChoice;
    }
}
