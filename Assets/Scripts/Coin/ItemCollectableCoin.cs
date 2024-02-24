using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    protected override void Collect()
    {
        ItemManager.Instance.AddCount();
        CollectCoin();

    }

    public float duration = 1f; // Duração da animação

    public void CollectCoin()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(gameObject.transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360));

        // Adiciona uma animação de escala à sequência
        sequence.Join(gameObject.transform.DOScale(Vector3.zero, duration));

        // Callback para destruir o objeto quando a animação terminar
        sequence.OnComplete(() => Destroy(gameObject));
    }
}
