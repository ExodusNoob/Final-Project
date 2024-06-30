using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneShop : MonoBehaviour
{
    public GameObject ButtonShop; //Boton que llevara a la tienda
    public string LoadScene; //Nombre de la Escena a la que iremos
    public string CurrentScene;
    private bool IsColliding = false; //Un booleano para saber si el jugador esta en colisión
    public PlayerData PlayerData; //Se declara la variable para que sea accesible
    public RelojControl RelojControl;
    void Awake()
    {
        PlayerData = FindObjectOfType<PlayerData>(); //Se referencia para poder usar sus componentes
    }
    void Start()
    {
            PlayerData.LoadPlayerData(CurrentScene); //Carga la ultima posición del jugador en la escena
        ButtonShop.SetActive(false); //El boton empezara sin activar para que no moleste en la pantalla
    }
    void OnTriggerEnter2D(Collider2D collider) //Segun el gameObject se activara el boton
    {
        if (collider.CompareTag("Player"))
        {
            ButtonShop.SetActive(true); //Se activa el boton
            IsColliding = true; //Detecta que el jugador esta colisionando y pone el bool en "true"
        }
    }
    public void ChangeScene() //El boton tomara este metodo como opción para cambiar la escena
    {
        PlayerData.SavePlayerInventory();
        RelojControl.SaveRelojTimer();
        PlayerData.SavePlayerData(CurrentScene); //Guardamos la info de nuestro jugador
        SceneManager.LoadScene(LoadScene);
    }

    void OnTriggerExit2D(Collider2D collider) //Segun el gameObject se desactivara el boton
    {
        if (collider.CompareTag("Player"))
        {
            if (ButtonShop != null) //Se asegura de que el objeto exista
            {
                ButtonShop.SetActive(false); // Se desactiva el boton
                IsColliding = false; // La colisión es falsa
            }
        }
    }
    void Update()
    {
        if (IsColliding == true && Input.GetKeyDown(KeyCode.E)) //Mientras este en colision y se presione la tecla E, iremos a la otra escena
        {
            PlayerData.SavePlayerInventory();
            RelojControl.SaveRelojTimer();
            PlayerData.SavePlayerData(CurrentScene); //Guardamos la info de nuestro jugador en la escena
            SceneManager.LoadScene(LoadScene); 
        }
    }
}
