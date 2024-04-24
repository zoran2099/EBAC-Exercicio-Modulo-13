using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private int _LookToLeft = -1;
    private int _LookToRight = 1;
    public float TurnDuration = .2f;

    public Rigidbody2D myRigidbody;



    [Header("Player Setup")]
    public SOPlayerSetup playerSetup;
    private bool isAlive = true;    

    private float _currentSpeed;



    public Ease ease = Ease.OutBack;


    private Animator _currentAnimator;

    [SerializeField]
    private HealthBase _healthBase;


    [Header("Jump Collision check")]    
    public float distToGround;    
    public float spaceToGround = .1f;

    [Header("Jump SFX")]
    public PlayAudioClipsRandom PlayAudioClipsRandom;

    [Header("End Game")]
    public GameObject UIMenu;
    public TextMeshProUGUI textEndGame;
    public AudioSource AudioEndGame;
    public AudioTransition AudioTransition;

    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnDeath += OnPlayerDeath;

        }

        _currentAnimator = Instantiate(playerSetup.animator, gameObject.transform);

        VFXManager.Instance.PlayVFXByType(VFXManager.VFX_Type.RUN, gameObject.transform);

    }

    private void OnPlayerDeath()
    {
        isAlive = false;

        _healthBase.OnDeath -= OnPlayerDeath;
        _currentAnimator.SetTrigger(playerSetup.triggerDeath);

        ShowMenuEndGame();
    }

    private void ShowMenuEndGame()
    {
        //chama a UI 
        if (UIMenu != null)
        {
            UIMenu.SetActive(true);
        }

        if (textEndGame != null) textEndGame.text = "You Died";

        if (AudioTransition != null) AudioTransition.MakeAudioMixerTransition();
        //play end death music 
        if (AudioEndGame != null) AudioEndGame.Play();
    }

    // Update is called once per frame
    void Update() { 
        IsGrounded();
        if (isAlive)
        {
            HandleMoviment();
            HandleJump();

        }
    }

    


    private bool IsGrounded()
    {
        // O DrawRay está aí para ajudar o Designer a visualiar o espaço e o movimento de pulo do Player para eventual ajuste fino
        Debug.DrawRay(transform.position, -Vector2.up * distToGround, Color.magenta, spaceToGround);
        
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround );
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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            myRigidbody.velocity = Vector2.up * playerSetup.ForceJump;

            HandleScaleJump();

            PlayJumpVFX();

        }

    }

    private void PlayJumpVFX()
    {
        //Play jump vfx 
        VFXManager.Instance.PlayVFXByType(VFXManager.VFX_Type.JUMP, transform);
        
        //Play jump sfx 
        if (PlayAudioClipsRandom != null) PlayAudioClipsRandom.PlayRandom();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("END_GAME"))
        {
            isAlive = false;
            _currentAnimator.SetBool(playerSetup.activateAnimation, false);
        }
    }

}
