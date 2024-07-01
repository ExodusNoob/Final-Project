using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerData playerData;
    public int TrigoPlayer = 0;
    public int Money = 0;
    public int CowQuantity = 0;
    private void Awake()
    {
        playerData = FindAnyObjectByType<PlayerData>();
    }
    private void Start()
    {
        playerData.LoadPlayerInventory();
    }
    public static PlayerInventory operator +(PlayerInventory player)
    {
        player.TrigoPlayer += 1;
        return player;
    }
    public static PlayerInventory operator +(PlayerInventory player, int quantity)
    {
        player.TrigoPlayer += quantity;
        return player;
    }
    public static PlayerInventory operator -(PlayerInventory player)
    {
        player.TrigoPlayer -= 1;
        if (player.TrigoPlayer < 0)
        {
            player.TrigoPlayer = 0;
        }
        return player;
    }
    public static PlayerInventory operator -(PlayerInventory player, int quantity)
    {
        player.TrigoPlayer -= quantity;
        if (player.TrigoPlayer < 0)
        {
            player.TrigoPlayer = 0;
        }
        return player;
    }
    public static PlayerInventory operator ++(PlayerInventory player)
    {
        player.Money += 1;
        return player;
    }

    public static PlayerInventory operator --(PlayerInventory player)
    {
        player.Money -= 1;
        if (player.Money < 0)
        {
            player.Money = 0;
        }
        return player;
    }

    public static PlayerInventory operator +(PlayerInventory player, float money)
    {
        player.Money += Mathf.RoundToInt(money);
        return player;
    }

    public static PlayerInventory operator -(PlayerInventory player, float money)
    {
        player.Money -= Mathf.RoundToInt(money);
        if (player.Money < 0)
        {
            player.Money = 0;
        }
        return player;
    }
    public void AddCow()
    {
        CowQuantity += 1;
    }
}
