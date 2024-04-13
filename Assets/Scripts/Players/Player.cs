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



    [Header("Player Setup")]
    public SOPlayerSetup playerSetup;

    private float _currentSpeed;



    public Ease ease = Ease.OutBack;


    private Animator _currentAnimator;

    [SerializeField]
    private HealthBase _healthBase;

    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnDeath += OnPlayerDeath;

        }

        _currentAnimator = Instantiate(playerSetup.animator, gameObject.transform);
    }

    private void OnPlayerDeath()
    {

        _healthBase.OnDeath -= OnPlayerDeath;
        _currentAnimator.SetTrigger(playerSetup.triggerDeath);
        
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
            _currentSpeed = playerSetup.speedRun;
        }
        else
        {
            _currentSpeed = playerSetup.speed;
            
        }
     
            
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * _fx_time.deltaTime); têm lag
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != _LookToLeft)
            {
                myRigidbody.transform.DOScaleX(_LookToLeft, TurnDuration);
            }

            _currentAnimator.SetBool(playerSetup.activateAnimation, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * _fx_time.deltaTime); têm lag
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != _LookToRight)
            {
                myRigidbody.transform.DOScaleX(_LookToRight, TurnDuration);
            }
            _currentAnimator.SetBool(playerSetup.activateAnimation, true);
        } else
        {
            _currentAnimator.SetBool(playerSetup.activateAnimation, false);
        }
            
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += playerSetup.Frition;

        } else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= playerSetup.Frition;

        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            myRigidbody.velocity = Vector2.up * playerSetup.ForceJump;

            HandleScaleJump();  
        }

    }

    private void HandleScaleJump()
    {        

        myRigidbody.transform.localScale = new Vector2(myRigidbody.transform.localScale.x < 0 ? -1 : 1, 1);

        DOTween.Kill(myRigidbody.transform);

        myRigidbody.transform.DOScaleY(playerSetup.jumpScaleY, playerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(playerSetup.jumpScaleX * myRigidbody.transform.localScale.x , playerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }


    public void DestroyMe()
    {
        Destroy(gameObject);

    }
}
