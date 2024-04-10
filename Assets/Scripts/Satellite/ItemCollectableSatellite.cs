using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableSatellite : ItemCollectableBase
{

    private bool _isCollectable = true;

    protected override void Collect()
    {
        if (!_isCollectable) return;

        ItemManager.Instance.AddSatellite();

        CollectSatellite();


        _isCollectable = false;
    }

    private void CollectSatellite()
    {
        gameObject.SetActive(false);
    }
}
