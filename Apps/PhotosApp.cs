using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotosApp : MonoBehaviour
{
    private SaveObject so;
    [SerializeField] private Texture[] Images;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private bool[] pandas = new bool[6];

    void OnEnable()
    {
        so = GameManager.instance.so;

        for (int i = 0; i < pandas.Length; i++)
        {
            if (so.pandas[i] == true &&
                pandas[i] == false)
            {
                pandas[i] = true;
                GameObject newPrefab = prefab;
                newPrefab.GetComponent<RawImage>().texture = Images[i];
                Instantiate(newPrefab, container);
            }
        }
    }
}
