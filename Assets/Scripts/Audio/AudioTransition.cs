using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot audioMixerSnapshot;
    public float transitionTime = .1f;

    public void MakeAudioMixerTransition(){ 
        if (audioMixerSnapshot != null) audioMixerSnapshot.TransitionTo(transitionTime);    
    }
}
