using Ebac.Core.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton3<ItemManager>
{
    public int _count = 0;

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

    }
}
