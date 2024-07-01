using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] audiosources;
    private void Awake()
    {
        audiosources = GetComponents<AudioSource>();
    }
    public void PlaySound(int reference)
    {
        if (reference >= 0 && reference < audiosources.Length)
        {
            audiosources[reference].Play();
        }
    }
    public void StopSound(int reference)
    {
        if (reference >= 0 && reference < audiosources.Length)
        {
            audiosources[reference].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
