using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClipsRandom : MonoBehaviour
{
    public List<AudioClip> ClipList;
    public List<AudioSource> SourceList;

    private int _index = 0;

    public void PlayRandom()
    {
        if (_index >= SourceList.Count) _index = 0;

        var audioSource = SourceList[_index];
        
        audioSource.clip = ClipList[Random.Range(0, ClipList.Count)];

        audioSource.Play();
        _index++;

    }
}
