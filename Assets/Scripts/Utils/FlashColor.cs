using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public int Loops = 4;
    public List<SpriteRenderer> renderers;

    public Color color = Color.red;

    public float duration = .5f;


    private Tween _currentTween;

    private void OnValidate()
    {

        renderers = new List<SpriteRenderer>();
        foreach (var item in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            renderers.Add(item);
        }

        
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A)) {
            Flash();
        }*/
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            renderers.ForEach(item => { item.color = Color.white; });
        }
        renderers.ForEach(item =>
        {
            _currentTween = item.DOColor(color, duration).SetLoops(Loops, LoopType.Yoyo);

        });
    }
}
