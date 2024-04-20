using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatTrigger : MonoBehaviour
{
    public string Tag = "Player";
    public AudioSource AudioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.CompareTag(Tag)) AudioSource.Play();
    }
}
