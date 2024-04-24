using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string Tag = "Player";
    public GameObject UIMenu;

    public AudioTransition AudioTransition;

    public AudioSource AudioEndGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.CompareTag(Tag)) UIMenu.SetActive(true);   

        if (AudioEndGame != null) AudioEndGame.Play();
        
        
        if (AudioTransition!= null) AudioTransition.MakeAudioMixerTransition();
    }
}
