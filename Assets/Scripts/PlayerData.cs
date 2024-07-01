using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject Player;
    private string PosCultivos = "Cultivos";
    private string PosTienda = "Tienda";
    private string PosCows = "Vacas";
    public PlayerInventory playerInventory;
    private void Awake()
    {
        playerInventory = FindAnyObjectByType<PlayerInventory>();
    }
    private void Start()
    {

    }
    public void SavePlayerData(string ActualScene) //Se utiliza para poder guardar la información del jugador al salir de la escena de Cultivos
    {
        if (ActualScene == PosCultivos || ActualScene == PosTienda || ActualScene == PosCows)
        {
            PlayerPrefs.SetFloat(ActualScene + "X", Player.transform.position.x);
            PlayerPrefs.SetFloat(ActualScene + "Y", Player.transform.position.y);
            PlayerPrefs.Save();
        }

    }
    public void LoadPlayerData(string ActualScene)
    {
            float PosX = PlayerPrefs.GetFloat(ActualScene + "X");
            float PosY = PlayerPrefs.GetFloat(ActualScene + "Y");

        Vector2 savedPosition = new Vector2(PosX, PosY);
        Player.transform.position = savedPosition;
    }
    public void SavePlayerInventory()
    {
        PlayerPrefs.SetInt("InventaryTrigo", playerInventory.TrigoPlayer);
        PlayerPrefs.SetInt("InventaryMoney", playerInventory.Money);
        PlayerPrefs.SetInt("InvetaryCowQuantity", playerInventory.CowQuantity);
        PlayerPrefs.Save();
    }
    public void LoadPlayerInventory()
    {
        int trigoSaved = PlayerPrefs.GetInt("InventaryTrigo");
        int moneySaved = PlayerPrefs.GetInt("InventaryMoney");
        int cowquantitySaved = PlayerPrefs.GetInt("InvetaryCowQuantity");
        playerInventory.TrigoPlayer = trigoSaved;
        playerInventory.Money = moneySaved;
        playerInventory.CowQuantity = cowquantitySaved; 
    }
}
