using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtomManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = 2f;
    public float delay = 0.5f;
    public Ease Ease = Ease.OutBack;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        HideAllButtons();
        ShowAllButtons();
    }

    private void ShowAllButtons()
    {
        int i = 0;

        foreach (var button in buttons)
        {
            button.SetActive(true);
            button.transform.DOScale(1, duration).SetDelay( i * delay).SetEase(Ease);
            i++;
        }
    }

    private void HideAllButtons()
    {
        foreach (var button in buttons)
        {
            button.SetActive(false);
            button.transform.localScale = Vector3.zero;
        }
    }
}
