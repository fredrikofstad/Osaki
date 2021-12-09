using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public List<GameObject> food;
    public GameObject bag;
    public int foodCount;
    public bool hasBag;

    private void Start()
    {
        GameManager.instance.pause.Paused += OnPause;
        GameManager.instance.pause.Resumed += OnResume;
        foreach (GameObject thing in food)
        {
            thing.SetActive(false);
        }
    }
    public void ActivateFood(int index)
    {
        food[index].SetActive(true);
        Debug.Log(index);
        foodCount++;
        print(foodCount);

    }
    public void Bag()
    {
        foreach (GameObject item in food)
            item.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        bag.SetActive(true);
        hasBag = true;
    }
    private void OnPause()
    {
        gameObject.SetActive(false);
    }
    private void OnResume()
    {
        gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        GameManager.instance.pause.Paused -= OnPause;
        GameManager.instance.pause.Resumed -= OnResume;
    }

}
