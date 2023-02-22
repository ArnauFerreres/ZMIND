using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumenController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] public AudioSource soundPlayer;

    [SerializeField] public Slider sliderMusic;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volumen"))
        {
            sliderMusic.value = PlayerPrefs.GetFloat("Volumen");
        }
        else 
        { 
            sliderMusic.value = 0.5f; 
        }
    }

    public void ControlVolumen(float sliderAudio)
    {
        audioMixer.SetFloat("Volumen", Mathf.Log10(sliderAudio) * 20);
        PlayerPrefs.SetFloat("Volumen", sliderAudio);
    }

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }


}
