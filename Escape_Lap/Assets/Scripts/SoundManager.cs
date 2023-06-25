using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider Sound;

    public void SetVolume()
    {
        audioMixer.SetFloat("Sound", Mathf.Log10(Sound.value)*20);
    }
}
