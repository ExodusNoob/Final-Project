using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerData playerData;
    public int TrigoPlayer;
    public int Money;
    public int CowQuantity;
    private string IsFirstTime = "yes";
    private void Awake()
    {
        playerData = FindAnyObjectByType<PlayerData>();
    }
    private void Start()
    {
        IsFirstTime = PlayerPrefs.GetString("FirstTime");
        playerData.LoadPlayerInventory();
        if (IsFirstTime == "yes")
        {
            TrigoPlayer = 4;
            IsFirstTime = "false";
            PlayerPrefs.SetString("FirstTime", IsFirstTime);
            PlayerPrefs.Save();
        }
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
