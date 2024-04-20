using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string Tag = "Player";
    public GameObject UIMenu;

    public PauseGameManger PauseGameManger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.CompareTag(Tag)) UIMenu.SetActive(true);   

        if (PauseGameManger != null) PauseGameManger.PauseGame();
    }
}
