using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;

    private Coroutine _currentCoroutine;
    
    [SerializeField]
    private float _timeBetweenShoots = .3f;

    public Transform playerSideReference;

    private void Start()
    {
        if (playerSideReference == null)
        {
            playerSideReference = GetComponentInParent<Rigidbody2D>().transform;

        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_timeBetweenShoots);

        }
    }

    public void Shoot()
    {
        var projecitl = Instantiate(prefabProjectile) ;
        projecitl.transform.position = positionToShoot.position;
        projecitl.side = playerSideReference.transform.localScale.x;
    }
}
