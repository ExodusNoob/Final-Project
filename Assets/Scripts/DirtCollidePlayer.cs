using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCollidePlayer : MonoBehaviour
{
    public bool IsColliding = false;
    public GameObject Trigo;
    public Color ColorDirtSembrada;
    public Color ColorDirtNormal;
    public CocecharTrigo CocecharTrigo;
    public PlayerInventory PlayerInventory;
    public bool EstaSembrada = false;
    private SpriteRenderer _compSpriteRenderer;
    private BoxCollider2D boxCollider;
    public float TiempoDeCocecha;
    public bool startTimer;
    public string IsItPlanted = "no";
    public string IsItTrigoActive = "no";
    public string nombre;

    void Awake()
    {
        CocecharTrigo = FindObjectOfType<CocecharTrigo>();
        PlayerInventory = FindAnyObjectByType<PlayerInventory>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        nombre = this.name;
        Trigo = transform.Find("trigo").gameObject;
        IsItPlanted = PlayerPrefs.GetString(this.name, IsItPlanted);
        IsItTrigoActive = PlayerPrefs.GetString(this.name + "Trigo", IsItTrigoActive);
        if (IsItPlanted == "yes")
        {
            SetColorDirt();
        }
        if (IsItTrigoActive == "no")
        {
            Trigo.SetActive(false);
        }
    }
    private void SaveYesOrNot()
    {
        PlayerPrefs.SetString(this.name, IsItPlanted);
        PlayerPrefs.Save();
    }
    private void SaveTrigoState()
    {
        PlayerPrefs.SetString(this.name + "Trigo", IsItTrigoActive);
        PlayerPrefs.Save();
    }
    private void SetColorDirt()
    {
        if (PlayerInventory.TrigoPlayer > 0)
        {
            if (IsItPlanted == "no")
            {
                CocecharTrigo.PlantarTrigoResta();

            }
            IsItPlanted = "yes";
            SaveYesOrNot();
            IsItTrigoActive = "no";
            SaveTrigoState();
            _compSpriteRenderer.color = ColorDirtSembrada;
            startTimer = true;
            EstaSembrada = true;
            boxCollider.enabled = false;
        }
        
    }
    private void SetColorOffDirt()
    {
        _compSpriteRenderer.color = ColorDirtNormal;
        boxCollider.enabled = true;
    }
    public void ActivateTrigo()
    {
        Trigo.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D collider) //Segun el gameObject se activara el Trigo
    {
        if (collider.CompareTag("Player"))
        {
            IsColliding = true; //La colision es verdadera
        }
    }
    void OnTriggerExit2D(Collider2D collider) //Segun el gameObject se desactivara el boton
    {
        if (collider.CompareTag("Player"))
        {
                IsColliding = false; // La colisión es falsa
        }
    }

    void Update()
    {
        if (EstaSembrada == false)
        {
            Trigo.SetActive(false);
        }
        if (startTimer == true)
        {
            TiempoDeCocecha = TiempoDeCocecha + Time.deltaTime;
            if (TiempoDeCocecha >= 20)
            {
                TiempoDeCocecha = 0;
                ActivateTrigo();
                SetColorOffDirt();
                startTimer = false;
            }
        }
        if (IsColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            if (EstaSembrada == false)
            {
                SetColorDirt();
            }
            else
            {
                Trigo.SetActive(false);
                EstaSembrada = false;
                IsItPlanted = "no";
                CocecharTrigo.CocecharTrigoSuma();
                SaveYesOrNot();
            }
        }
    }
}
