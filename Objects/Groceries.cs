using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groceries : MonoBehaviour
{
    public Basket basket;

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
    public int FoodCount()
    {
        return basket.foodCount;
    }
    public bool hasBag()
    {
        return basket.hasBag;
    }

}
