using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public List<GameObject> food;

    private void Start()
    {
        foreach(GameObject thing in food)
        {
            thing.SetActive(false);
        }
    }
    public void ActivateFood(int index)
    {
        food[index].SetActive(true);
        Debug.Log(index);

    }

}
