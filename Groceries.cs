using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groceries : MonoBehaviour
{
    [SerializeField]
    private Basket basket;

    private void Start()
    {
        Invoke("FindBasket", 1f);
    }

    public void ActivateFood(int food)
    {
        basket.ActivateFood(food);
    }
    private void FindBasket()
    {
        basket = GetComponentInChildren<Basket>();
    }

}
