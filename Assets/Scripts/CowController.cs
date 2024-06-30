using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Vector2 WayPoint;
    public bool IsMoving = false;
    public int TiempoEnEspera;
    public int speed = 4;
    private float Llegada = 0.1f;
    private SpriteRenderer _compSpriteRenderer;
    private Animator _compAnimator;
    private bool DirectionCow;
    public float CurrentTime;
    public int LimitTime;
    public int AnimateIn;
    public bool AnimationTrue = true;
    void Awake()
    {
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        _compAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        RandomPoint();
    }
    void RandomPoint()
    {
        WayPoint = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        IsMoving = true;
        DirectionCow = WayPoint.x > transform.position.x;
        if (DirectionCow == true)
        {
            _compSpriteRenderer.flipX = true; 
        }
        else
        {
            _compSpriteRenderer.flipX = false;
        }
    }
    void Update()
    {
        _compAnimator.SetBool("IsCowWalking", IsMoving);
        if (IsMoving == false)
        {
            CurrentTime = CurrentTime + Time.deltaTime;

            if (CurrentTime >= AnimateIn)
            {
                    _compAnimator.SetBool("CowEating", AnimationTrue);


            }

            if (CurrentTime >= LimitTime)
            {
                AnimationTrue = false;
                _compAnimator.SetBool("CowEating", AnimationTrue);
                RandomPoint();
            }
        }
    }
    void FixedUpdate()
    {
        if (IsMoving == true)
        {
            MoveToPosition();
        }
    }
    void MoveToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoint) < Llegada)
        {
            IsMoving = false;
            LimitTime = Random.Range(5,20);
            AnimateIn = Random.Range(3,15);
            AnimationTrue = true;
            CurrentTime = 0;
        }
    }
}
