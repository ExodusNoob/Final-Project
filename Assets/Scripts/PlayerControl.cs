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
    public SoundManager SoundManager;
    public bool IsMoving = false;
    public int firstmove;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        _compAnimator = GetComponent<Animator>();
    }
    void SetSteps()
    {
        if (IsMoving == true && firstmove == 1)
        {
            SoundManager.PlaySound(1);
        }
    }
    void StopSteps()
    {
        firstmove = 0;
        SoundManager.StopSound(1);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        IsMoving = horizontal != 0 || vertical != 0;
        if (IsMoving)
        {
            firstmove += 1;
            SetSteps();
        }
        else
        {
            StopSteps();
        }
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
