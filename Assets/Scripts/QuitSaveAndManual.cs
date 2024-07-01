using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitSaveAndManual : MonoBehaviour
{
    public Slider SoundSlider;
    public SoundManager soundmanager;
    public float ValueSoundVolume = 1;
    public GameObject Manual;
    public GameObject UiObjects;
    public bool ConfirmActivation = false;
    public PlayerData playerdata;
    public CurrentScene currentScene;
    private void Awake()
    {
    }
    void Start()
    {
        UiObjects.SetActive(false);
        Manual.SetActive(false);
        LoadSoundVolume();
    }
    public void ActiveUI()
    {
        soundmanager.PlaySound(0);
        if (ConfirmActivation == true)
        {
            UiObjects.SetActive(false);
            ConfirmActivation = false;
        }
        else
        {
            UiObjects.SetActive(true);
            ConfirmActivation = true;
        }
    }
    public void UpdateSoundsVolume()
    {
            for (int i = 0; soundmanager.audiosources.Length > i; i++)
            {
            soundmanager.audiosources[i].volume = SoundSlider.value;
            }
        ValueSoundVolume = SoundSlider.value;
            SaveVolumeSound();
        
    }
    void SaveVolumeSound()
    {
        PlayerPrefs.SetFloat("VolumeSound", ValueSoundVolume);
        PlayerPrefs.Save();
    }
    private void LoadSoundVolume()
    {
        ValueSoundVolume = PlayerPrefs.GetFloat("VolumeSound");
    }
    public void ActivateManual()
    {
        soundmanager.PlaySound(0);
        Manual.SetActive(true);
    }
    public void DesactivateManual()
    {
        soundmanager.PlaySound(0);
        Manual.SetActive(false);

    }
    public void SaveDataPlayerAndPosition()
    {
        soundmanager.PlaySound(0);
        string LastScene = PlayerPrefs.GetString("LastScene");
        playerdata.SavePlayerData(LastScene);
        playerdata.SavePlayerInventory();
    }
    public void QuitGame()
    {
        SaveDataPlayerAndPosition();
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ConfirmActivation == true)
            {
                UiObjects.SetActive(false);
                ConfirmActivation = false;
            }
            else
            {
                UiObjects.SetActive(true);
                ConfirmActivation = true;
            }
        }
    }
}
