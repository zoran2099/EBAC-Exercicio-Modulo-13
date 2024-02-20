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


    public Rigidbody2D myRigidbody;



    [Header("Speed Setup")]
    public Vector2 Frition = new Vector2(-.1f,0f);
    public float speed;
    public float speedRun = 0;
    public float ForceJump = 0;
    private float _currentSpeed;



    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;


    // Update is called once per frame
    void Update() { 
        HandleMoviment();
        HandleJump();
    }
    void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
            
        }
     
            
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime); têm lag
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime); têm lag
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

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

            myRigidbody.velocity = Vector2.up * ForceJump;

            HandleScaleJump();
        }

    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.localScale = Vector2.one;
        DOTween.Kill(myRigidbody.transform);

        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
