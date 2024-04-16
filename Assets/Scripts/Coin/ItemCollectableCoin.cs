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

    [Header("Sound Settings")]
    public AudioSource AudioSource;

    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
        if (AudioSource != null) AudioSource.transform.SetParent(null);
    }

    protected override void Collect()
    {
        if (!_isCollectable) return;

        ItemManager.Instance.AddCount();


        Debug.Log("TESTE");


        OnCollect();

        _isCollectable = false;
        // Talvez esssa seja a instru��o que esteja desativando os objetos de 
        // forma precipitada o que faz levar a usar Invoke(nameof(CleanObjects), _fx_time);
        gameObject.SetActive(false);

        Invoke(nameof(CleanObjects), _fx_time);

    }

    protected override void OnCollect()
    {
        if (ParticleSystem != null) { 

            ParticleSystem.Play(); 
        }

        if (AudioSource != null) { 
            AudioSource.Play(); 
        }
        //FXCollectCoinDotTween();
    }

    public void CleanObjects()
    {
        if (ParticleSystem != null)
        {
            ParticleSystem.gameObject.SetActive(false);
            Destroy(ParticleSystem.gameObject);
        }

        if (AudioSource != null)
        {
            AudioSource.gameObject.SetActive(false);
            Destroy(AudioSource.gameObject);
        }


        Destroy(gameObject);
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
