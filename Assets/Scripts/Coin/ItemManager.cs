using Ebac.Core.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton3<ItemManager>
{
    private int _count = 0;

    public TextMeshProUGUI textCoinsPlayer;

    public int Count()
    {
        return _count;
    }

    private void Start()
    {
        Reset(); 
        
    }

    private void Reset()
    {
        _count = 0;
    }

    public void AddCount(int amount = 1)
    {
        _count += amount;
        ScoreCoins();

    }

    public void ScoreCoins()
    {
        textCoinsPlayer.text = "x "+_count.ToString();


    }
}
