using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    
    public int damaged = 10;

    public Animator animator;

    public String triggerAttack = "Attack";
    public String triggerDeath= "Death";

    public HealthBase health;
    
    [SerializeField]
    private float _timeToDestroy= 2f;

    private void Awake()
    {
        if (health != null)
        {
            health.OnDeath += OnEnemyDeath;
        }
    }


    private void OnEnemyDeath()
    {
        
        health.OnDeath -= OnEnemyDeath;
        PlayDeathAnimation();
        Destroy(gameObject,_timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        var healthBase = collision.gameObject.GetComponent<HealthBase>();
        
        if (healthBase != null) { 
            healthBase.Damage(damaged);
            PlayAttackAnimation();
            
        }

    }


    public void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }


    public void Damage(int damaged)
    {
        health.Damage(damaged);
    }
}
