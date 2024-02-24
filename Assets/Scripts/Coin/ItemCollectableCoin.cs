using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    private bool _isCollectable = true;

    protected override void Collect()
    {
        if (!_isCollectable) return;

        ItemManager.Instance.AddCount();
        CollectCoin();
        _isCollectable=false;
   
    }

    public float duration = 1f; // Dura��o da anima��o

    public void CollectCoin()
    {       

        Sequence sequence = DOTween.Sequence();

        sequence.Append(gameObject.transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360));

        // Adiciona uma anima��o de escala � sequ�ncia
        sequence.Join(gameObject.transform.DOScale(Vector3.zero, duration));

        // Callback para destruir o objeto quando a anima��o terminar
        // aqui n�o consegui usar o Destroy(gameObject) por causa de mensagens de alerta do DoTween
        sequence.OnComplete(() => gameObject.SetActive(false));



    }

   
}
