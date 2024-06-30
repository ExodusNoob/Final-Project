using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneCows : MonoBehaviour
{
    public GameObject ButtonCows; //Boton que nos llevara con las vacas
    public string LoadScene; //Nombre de la Escena a la que iremos
    public string CurrentScene;
    private bool IsColliding = false; //Un booleano para saber si el jugador esta en colisión
    public PlayerData PlayerData; //Declaramos la variable
    public RelojControl RelojControl;
    void Awake()
    {
        PlayerData = FindObjectOfType<PlayerData>(); //Referenciamos los componentes
    }
    void Start()
    {
        PlayerData.LoadPlayerData(CurrentScene);
        ButtonCows.SetActive(false); //El boton empezara desactivado para no estorbar
    }
    void OnTriggerEnter2D(Collider2D collider) //Segun el gameObject se activara el boton
    {
        if (collider.CompareTag("Player"))
        {
            ButtonCows.SetActive(true); //El boton se activa
            IsColliding = true; //La colision es verdadera
        }
    }
    public void ChangeScene() //El boton tomara este metodo como opción para cambiar la escena
    {
        RelojControl.SaveRelojTimer();
        PlayerData.SavePlayerData(CurrentScene); //Guardamos la info de nuestro jugador
        SceneManager.LoadScene(LoadScene); //Cargamos otra escena
    }
    void OnTriggerExit2D(Collider2D collider) //Segun el gameObject se desactivara el boton
    {
        if (collider.CompareTag("Player"))
        {
            if (ButtonCows != null) //Nos aseguramos que el boton no sea nulo y este referenciando a un objeto destruido
            {
                ButtonCows.SetActive(false); // Se desactiva el boton
                IsColliding = false; // La colisión es falsa
            }
        }
    }
    void Update()
    {
        if (IsColliding == true && Input.GetKeyDown(KeyCode.E)) //Al colisionar y presionar E te llevara a la escena
        {
            RelojControl.SaveRelojTimer();
            PlayerData.SavePlayerData(CurrentScene); //Guardamos la info de nuestro jugador en la escena
            SceneManager.LoadScene(LoadScene);
        }
    }
}
