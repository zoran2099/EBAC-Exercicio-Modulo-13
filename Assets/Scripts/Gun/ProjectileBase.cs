using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float side = 1;
    
    [SerializeField]
    private float _timeToDestroy = 1f;

    public int damage = 3;



    private void Update()
    {
        transform.Translate( direction * Time.deltaTime * side);
    }

    private void Awake()
    {
        Destroy(gameObject,_timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();
        
        if (enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}
