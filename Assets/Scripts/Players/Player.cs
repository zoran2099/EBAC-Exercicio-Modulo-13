using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private int _LookToLeft = -1;
    private int _LookToRight = 1;
    public float TurnDuration = .2f;

    public Rigidbody2D myRigidbody;



    [Header("Speed Setup")]
    public Vector2 Frition = new Vector2(-.1f,0f);
    
    public SOFloat speed;
    public SOFloat speedRun;
    public SOFloat ForceJump;
    private float _currentSpeed;



    [Header("Animation Setup")]
    public SOFloat jumpScaleY;
    public SOFloat jumpScaleX;
    public SOFloat animationDuration;
    public Ease ease = Ease.OutBack;


    [Header("Animation Player")]
    public string activateAnimation = "Run";
    public string triggerDeath = "Death";
    public Animator animator;

    [SerializeField]
    private HealthBase _healthBase;

    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnDeath += OnPlayerDeath;

        }
    }

    private void OnPlayerDeath()
    {

        _healthBase.OnDeath -= OnPlayerDeath;
        animator.SetTrigger(triggerDeath);
        
    }

    // Update is called once per frame
    void Update() { 
        HandleMoviment();
        HandleJump();
    }
    void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun.value;
        }
        else
        {
            _currentSpeed = speed.value;
            
        }
     
            
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime); t�m lag
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != _LookToLeft)
            {
                myRigidbody.transform.DOScaleX(_LookToLeft, TurnDuration);
            }

            animator.SetBool(activateAnimation, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime); t�m lag
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != _LookToRight)
            {
                myRigidbody.transform.DOScaleX(_LookToRight, TurnDuration);
            }
            animator.SetBool(activateAnimation, true);
        } else
        {
            animator.SetBool(activateAnimation, false);
        }
            
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += Frition;

        } else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= Frition;

        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            myRigidbody.velocity = Vector2.up * ForceJump.value;

            HandleScaleJump();  
        }

    }

    private void HandleScaleJump()
    {        

        myRigidbody.transform.localScale = new Vector2(myRigidbody.transform.localScale.x < 0 ? -1 : 1, 1);

        DOTween.Kill(myRigidbody.transform);

        myRigidbody.transform.DOScaleY(jumpScaleY.value, animationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX.value * myRigidbody.transform.localScale.x , animationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }


    public void DestroyMe()
    {
        Destroy(gameObject);

    }
}
