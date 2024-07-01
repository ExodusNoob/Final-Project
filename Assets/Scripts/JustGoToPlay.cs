using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustGoToPlay : MonoBehaviour
{
    public SoundManager SoundManager;
    public string LastScene;
    public void PlayGame()
    {
        SoundManager.PlaySound(0); //no suena, pero si llama a la canción
        SceneManager.LoadScene(LastScene);
    }
}
