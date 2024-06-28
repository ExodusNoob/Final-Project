using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speedPlayer;
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    private Animator _compAnimator;
    public float horizontal;
    public float vertical;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        _compAnimator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        _compAnimator.SetInteger("IsWalkingBackward", (int)vertical);
        _compAnimator.SetInteger("IsWalkingStraight", (int)vertical);
        _compAnimator.SetInteger("IsWalkingSideway", (int)horizontal);

        if (horizontal >= 1)
        {
            _compSpriteRenderer.flipX = true;
        }
        else if (horizontal <= 1)
        {
            _compSpriteRenderer.flipX = false;
        }
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speedPlayer * horizontal, speedPlayer * vertical);
    }
}
