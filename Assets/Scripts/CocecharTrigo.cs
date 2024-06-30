using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocecharTrigo : FarmingCultivos
{
    public int RandomTrigoCocechado;
    public PlayerInventory playerInventory;
    private void Awake()
    {
        playerInventory = FindAnyObjectByType<PlayerInventory>();
    }
    public void PlantarTrigoResta()
    {
        playerInventory.TrigoPlayer = playerInventory.TrigoPlayer -  1;
    }
    public void CocecharTrigoSuma()
    {
        RandomTrigoCocechado = Random.Range(2, 5);
        playerInventory.TrigoPlayer = playerInventory.TrigoPlayer + RandomTrigoCocechado;
    }
    void Update()
    {
    }
}
