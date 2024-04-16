using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Destroy(gameObject);
        //DOTWEEN ► Target or field is missing/null () ► The object of type 'Transform' has been destroyed but you are still trying to access it.
        //Your script should either check if it is null or you should not destroy the object.

        gameObject.SetActive(false);

        OnCollect();
    }

    protected virtual void OnCollect()
    {
        
    }


}
