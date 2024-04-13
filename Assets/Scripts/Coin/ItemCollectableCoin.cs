using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    [SerializeField]
    private float _fx_time = 2f;
    private bool _isCollectable = true;
    public float duration = 1f; // Dura��o da anima��o
    public ParticleSystem ParticleSystem;

    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }

    protected override void Collect()
    {
        if (!_isCollectable) return;

        ItemManager.Instance.AddCount();

        if (ParticleSystem != null)
        {
            ParticleSystem.Play();

        }
        //FXCollectCoinDotTween();

        _isCollectable = false;
        gameObject.SetActive(false);

        Invoke(nameof(CleanObjects), _fx_time);

    }

    public void CleanObjects()
    {
        if(ParticleSystem != null)
        {
            ParticleSystem.gameObject.SetActive(false);
            Destroy(ParticleSystem.gameObject);
            Destroy(gameObject);
        }
    }


    public void FXCollectCoinDotTween()
    {        
        Sequence sequence = DOTween.Sequence();

        sequence.Append(gameObject.transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360));

        // Adiciona uma anima��o de escala � sequ�ncia
        sequence.Join(gameObject.transform.DOScale(Vector3.zero, duration));
                
        // Callback para destruir o objeto quando a anima��o terminar
        // aqui n�o consegui usar o Destroy(gameObject) por causa de mensagens de alerta do DoTween
        sequence.OnComplete(() => gameObject.SetActive(false) );



    }

   
}
