using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer AudioMixerGroup;
    public string FloatParamName = "MyExposedParam";

    public void ChangeValue(float value = 0)
    {
        if (AudioMixerGroup != null) AudioMixerGroup.SetFloat(FloatParamName, value);

    }
}
