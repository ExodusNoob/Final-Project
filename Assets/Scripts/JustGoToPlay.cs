using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustGoToPlay : MonoBehaviour
{
    public string LastScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(LastScene);
    }
}
