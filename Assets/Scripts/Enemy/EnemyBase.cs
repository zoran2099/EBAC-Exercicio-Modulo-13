using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    
    public int damaged = 10;

    public Animator animator;

    public String triggerAttack = "Attack";



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
        animator?.SetTrigger(triggerAttack);
    }
}
