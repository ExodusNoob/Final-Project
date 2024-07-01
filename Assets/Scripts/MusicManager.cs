using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] AudioSource; 
    public float Timer;
    public int RandomMeta; //de 10 seg a 60 seg
    public int RandomMuxicArray;
    public bool IsPlaying;
    public Slider SliderVolume;
    public float ValueSaveVolume;
    private void Awake()
    {
        AudioSource = GetComponents<AudioSource>();
    }
    void Start()
    {
        LoadVolume();
        DontDestroyOnLoad(gameObject);
        RandomNumber();
    }
    public void UpdateVolumeMusic()
    {
        for (int i = 0; AudioSource.Length > i; i++)
        {
            AudioSource[i].volume = SliderVolume.value;
        }
        ValueSaveVolume = SliderVolume.value;
        SaveVolume();
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("VolumeMusic", ValueSaveVolume);
        PlayerPrefs.Save();
    }
    private void LoadVolume() 
    {
        ValueSaveVolume = PlayerPrefs.GetFloat("VolumeMusic"); 
    }
    void RandomNumber()
    {
        RandomMeta = Random.Range(10,60);
        RandomMuxicArray = Random.Range(0,AudioSource.Length);
    }
    void PlayRandomMusic()
    {
        IsPlaying = false;
        for (int i = 0; i < AudioSource.Length; i++)
        {
            if (AudioSource[i].isPlaying)
            {
                IsPlaying = true;
                break; 
            }
        }
        if (IsPlaying == false)
        {
            if (RandomMuxicArray >= 0 && RandomMuxicArray < AudioSource.Length)
            {
                AudioSource[RandomMuxicArray].Play();
            }
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= RandomMeta)
        {
            RandomNumber();
            PlayRandomMusic();
            Timer = 0;
        }
    }
}
