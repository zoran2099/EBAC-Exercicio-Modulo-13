using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    
    public int damaged = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Heheh");
        var healthBase = collision.gameObject.GetComponent<HealthBase>();
        
        healthBase?.Damage(damaged);    

    }

}
