using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindMusicManager : MonoBehaviour
{
    public Slider MusicSlider;
    public MusicManager musicmanager;
    private void Awake() //mis ojos se me caen we
    {
        musicmanager = FindAnyObjectByType<MusicManager>();
    }
    void Start()
    {
        
        musicmanager.SliderVolume = MusicSlider;
        MusicSlider.onValueChanged.AddListener(delegate {musicmanager.UpdateVolumeMusic();});
        MusicSlider.value = PlayerPrefs.GetFloat("VolumeMusic");
        musicmanager.UpdateVolumeMusic();
    }
}
