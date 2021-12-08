using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesApp : MonoBehaviour
{
    private SaveObject so;
    //consider enums
    [SerializeField] private GameObject[] tasks;
    [SerializeField] private GameObject[] groceries;
    private bool initialized;

    private void Start()
    {
        initialized = true;
        so = GameManager.instance.so;
    }
    private void OnEnable()
    {
        if (!initialized)
            return;
        so = GameManager.instance.so;
        Tasks();
    }

    private void Tasks()
    {
        int friends = so.friendCount;
        tasks[0].GetComponent<Text>().text = $"◯ Meet my friends [{friends}/{GameManager.maxFriends}]";
        if (friends > 4)
            tasks[0].GetComponentInChildren<RawImage>().enabled = true;
        int pandas = so.pandaCount;
        tasks[1].GetComponent<Text>().text = $"◯ See some pandas [{pandas}/{GameManager.maxPanda}]";
        if (pandas > 5)
            tasks[1].GetComponentInChildren<RawImage>().enabled = true;
        if(so.exercise)
            tasks[2].GetComponentInChildren<RawImage>().enabled = true;
        if (so.cafe)
            tasks[3].GetComponentInChildren<RawImage>().enabled = true;
        if (so.work)
            tasks[4].GetComponentInChildren<RawImage>().enabled = true;
        if (so.groceries)
            tasks[5].GetComponentInChildren<RawImage>().enabled = true;
    }

}
