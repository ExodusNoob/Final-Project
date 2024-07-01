using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    public GameObject prefabCow;
    public PlayerInventory playerInventory;
    void Start()
    {
        LoadCows();
    }
    private void LoadCows()
    {
        for (int i = 0; playerInventory.CowQuantity > i; i++)
        {
            Instantiate(prefabCow, GetRandomSpawn(), Quaternion.identity);
        }
    }
    private Vector2 GetRandomSpawn()
    {
        float x = Random.Range(-7.4f, 8);
        float y = Random.Range(-2.5f, 1.9f);
        return new Vector2(x,y);
    }
}
