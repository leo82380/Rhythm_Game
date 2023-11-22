using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    
    public enum AudioType
    {
        BGM,
        SFX
    }
    [SerializeField] private AudioType audioType;

    public void AudioControl(float sound)
    {
        sound = slider.value;
        if (audioType == AudioType.BGM)
        {
            if (sound <= 0.02f)
                audioMixer.SetFloat("BGM", -80f);
            audioMixer.SetFloat("BGM", Mathf.Log10(sound) * 20);
        }
        else if (audioType == AudioType.SFX)
        {
            if (sound <= 0.02f)
                audioMixer.SetFloat("SFX", -80f);
            audioMixer.SetFloat("SFX", Mathf.Log10(sound) * 20);
        }
    }
}
