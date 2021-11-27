using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public List<GameObject> food;
    public GameObject bag;

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

    }
    public void Bag()
    {
        foreach (GameObject item in food)
            item.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        bag.SetActive(true);
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
