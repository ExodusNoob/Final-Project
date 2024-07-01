using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderCollider : MonoBehaviour
{
    public GameObject Shop;
    public bool IsColliding = false;
    public PlayerInventory PlayerInventory;
    int TrigoVender = 5;
    int MoneyQuantity = 50;
    int CostCow = 250;

    private void Start()
    {
        Shop.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            IsColliding = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            if (Shop != null)
            {
                Shop.SetActive(false);
                IsColliding = false;
            }
        }
    }
    public void TradeTrigoForMoney()
    {
        if (PlayerInventory.TrigoPlayer >= TrigoVender)
        {
            PlayerInventory.TrigoPlayer -= TrigoVender;
            PlayerInventory.Money += MoneyQuantity;
        }
        else
        {
            Debug.Log("Mi loco, no tienes suficiente Trigo para vender");
        }
    }
    public void TradeMoneyForTrigo()
    {
        if (PlayerInventory.Money >= MoneyQuantity)
        {
            PlayerInventory.TrigoPlayer += TrigoVender;
            PlayerInventory.Money -= MoneyQuantity;
        }
        else
        {
            Debug.Log("Mi loco, no tienes suficiente Dinero para comprar");
        }
    }
    public void BuyACow()
    {
        if (PlayerInventory.Money >= CostCow)
        {
            PlayerInventory.Money -= CostCow;
            PlayerInventory.AddCow();
        }
        else
        {
            Debug.Log("Mi loco, no tienes suficiente Dinero para comprar una vaca");
        }
    }
    void Update()
    {
        if (IsColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            Shop.SetActive(true);
        }
    }
}
