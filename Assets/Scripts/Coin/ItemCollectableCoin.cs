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

    public float duration = 1f; // Duração da animação

    public void CollectCoin()
    {       

        Sequence sequence = DOTween.Sequence();

        sequence.Append(gameObject.transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360));

        // Adiciona uma animação de escala à sequência
        sequence.Join(gameObject.transform.DOScale(Vector3.zero, duration));

        // Callback para destruir o objeto quando a animação terminar
        // aqui não consegui usar o Destroy(gameObject) por causa de mensagens de alerta do DoTween
        sequence.OnComplete(() => gameObject.SetActive(false));



    }

   
}
