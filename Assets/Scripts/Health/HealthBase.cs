using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    private int _currentLife;
    private bool _isDead = false;

    public float delayToKill = .5f;

    [SerializeField]
    private FlashColor _flashColor;

    
    public Action OnDeath;
    
    private void Awake()
    {

        Init();
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();    
        }

    }


    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;

    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        
        _currentLife -= damage;

        if(_currentLife < 1)
        {
            Kill();

        }

        _flashColor.Flash();

    }

    private void Kill()
    {
        _isDead = true;
        if(destroyOnKill && gameObject != null)
        {
            Destroy(gameObject,delayToKill);

            //DOTWEEN ► Target or field is missing/null () ► The object of type 'Transform' has been destroyed but you are still trying to access it.
            //Your script should either check if it is null or you should not destroy the object.

        }

        OnDeath?.Invoke();    
    }

      
}
