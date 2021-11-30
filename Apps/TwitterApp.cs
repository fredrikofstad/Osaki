using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwitterApp : MonoBehaviour
{
    private SaveObject so;
    [SerializeField] private TwitterPost[] posts;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private ScrollRect scroll;
    private bool initialized; //cause wtf unity?

    private bool[] posted;
    private bool[] locked;

    private void Start()
    {
        initialized = true;
        posted = new bool[posts.Length];
        locked = new bool[posts.Length];
        so = GameManager.instance.so;
    }

    private void OnEnable()
    {
        if (!initialized)
            return;
        scroll.verticalNormalizedPosition = 1f;

        Unlock();

        for (int i = 0; i < posts.Length; i++)
        {
            if (posted[i])
                return;
            prefab.GetComponent<TwitterDisplay>().post = posts[i];
            Instantiate(prefab, container);
            prefab.transform.SetAsLastSibling();
            posted[i] = true;
        }
    }

    private void Unlock()
    {
        if (so.pandaCount < 5)
            Debug.Log("pandaMan Active");
        if(!so.cafe)
            Debug.Log("starbucks2");
        if (!so.exercise)
            Debug.Log("musk2");
        if (!so.work)
            Debug.Log("musk3");
        if (!so.groceries)
            Debug.Log("starbucks3");
        if (so.friendCount < 3)
            Debug.Log("anon");
        if (so.friendCount < 4)
            Debug.Log("anon2");


    }
}
