using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CurrentScene : MonoBehaviour
{
    public string currentsceneName;
    private string IsFirstTime = "Yes";
    void Start()
    {
        currentsceneName = SceneManager.GetActiveScene().name;
        if (IsFirstTime == "Yes")
        {
            currentsceneName = "Cultivos";
            LastSceneToCharge();
            IsFirstTime = "False";
            PlayerPrefs.SetString("IsFirstTimeNameScene", IsFirstTime);
            PlayerPrefs.Save();
        }
        else if (currentsceneName != "Menu")
        {
            LastSceneToCharge();
        }
        else
        {
            print("Bienvenidos al Himalaya!");
        }
    }
    public void LastSceneToCharge()
    {
        PlayerPrefs.SetString("LastScene", currentsceneName);
        PlayerPrefs.Save();
    }
}
