using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text TextMoney;
    public Text TextTrigo;
    public Text TextVaca;
    public PlayerInventory PlayerInventory;
    void Update()
    {
        TextMoney.text = "X" + PlayerInventory.Money;
        TextTrigo.text = "X" + PlayerInventory.TrigoPlayer;
        TextVaca.text = "X" + PlayerInventory.CowQuantity;
    }
}
