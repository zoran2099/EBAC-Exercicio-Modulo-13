using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{


    [Header("Player")]
    public GameObject playerPrefab;
    private GameObject _currentPlayer;

    [Header("Enenies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = 2f;
    public float delay = 0.5f;
    public Ease Ease = Ease.OutBack;


    private void Start()
    {
        SpawnPlayer();

    }

    private void SpawnPlayer()
    {

        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(Ease).From();

    }
}
