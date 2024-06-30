using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerData playerData;
    public int TrigoPlayer;
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
        return player;
    }
    public static PlayerInventory operator -(PlayerInventory player, int quantity)
    {
        player.TrigoPlayer -= quantity;
        return player;
    }
}
