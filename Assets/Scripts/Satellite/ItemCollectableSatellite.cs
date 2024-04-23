using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableSatellite : ItemCollectableBase
{

    private bool _isCollectable = true;

    [Header("Sound Settings")]
    public AudioSource AudioSource;

    private void Awake()
    {
        if (AudioSource != null) AudioSource.transform.SetParent(null);
    }

    protected override void Collect()
    {
        if (!_isCollectable) return;

        ItemManager.Instance.AddSatellite();

        CollectSatellite();

        if (AudioSource != null) AudioSource.Play();


        _isCollectable = false;
    }

    private void CollectSatellite()
    {
        gameObject.SetActive(false);
    }
}
