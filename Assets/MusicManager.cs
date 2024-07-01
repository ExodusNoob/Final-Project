using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] AudioSource; 
    public float Timer;
    public int RandomMeta; //de 10 seg a 60 seg
    public int RandomMuxicArray;
    public bool IsPlaying;
    private void Awake()
    {
        AudioSource = GetComponents<AudioSource>();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        RandomNumber();
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
