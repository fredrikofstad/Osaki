using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public List<GameObject> food;
    public GameObject bag;

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
    public void Packup()
    {
        foreach (GameObject item in food)
            item.SetActive(false);
        bag.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
    }

}
