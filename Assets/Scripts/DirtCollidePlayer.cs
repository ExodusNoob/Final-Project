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
    public bool starTimer;
    void Awake()
    {
        CocecharTrigo = FindObjectOfType<CocecharTrigo>();
        PlayerInventory = FindAnyObjectByType<PlayerInventory>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        Trigo = transform.Find("trigo").gameObject;
    }
    private void SetColorDirt()
    {
        if (PlayerInventory.TrigoPlayer > 0)
        {
            _compSpriteRenderer.color = ColorDirtSembrada;
            starTimer = true;
            EstaSembrada = true;
            boxCollider.enabled = false;
            CocecharTrigo.PlantarTrigoResta();
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
        if (starTimer == true)
        {
            TiempoDeCocecha = TiempoDeCocecha + Time.deltaTime;
            if (TiempoDeCocecha >= 20)
            {
                TiempoDeCocecha = 0;
                ActivateTrigo();
                SetColorOffDirt();
                starTimer = false;
            }
        }
        if (EstaSembrada == false)
        {
            Trigo.SetActive(false);
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
                CocecharTrigo.CocecharTrigoSuma();
            }
        }
    }
}
