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

    void OnEnable()
    {
        so = GameManager.instance.so;

        for (int i = 0; i < posts.Length; i++)
        {
            prefab.GetComponent<TwitterDisplay>().post = posts[i];
            Instantiate(prefab, container);
        }
    }
}
