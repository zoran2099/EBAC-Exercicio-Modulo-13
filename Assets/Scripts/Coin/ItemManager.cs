using Ebac.Core.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton3<ItemManager>
{
    [SerializeField]
    private SOInt _count;

    public int Count()
    {
        return _count.value;
    }

    private void Start()
    {
        Reset(); 
        
    }

    private void Reset()
    {
        _count.value = 0;
    }

    public void AddCount(int amount = 1)
    {
        _count.value += amount;
        ScoreCoins();

    }

    public void ScoreCoins()
    {
        
        //UIInGameManager.UpdateTextCoins("x " + _count.ToString());


    }
}
