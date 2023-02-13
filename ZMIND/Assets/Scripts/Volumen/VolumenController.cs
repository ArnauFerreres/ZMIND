using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class VolumenController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    [SerializeField] public AudioSource soundPlayer;

    public void ControlVolumen(float sliderAudio)
    {
        audioMixer.SetFloat("Volumen", Mathf.Log10(sliderAudio)*20);
    }

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }


}
