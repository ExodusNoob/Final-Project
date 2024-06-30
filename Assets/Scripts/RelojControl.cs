using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelojControl : MonoBehaviour
{
    public Text timerText;
    public float timer = 0;
    public int minute;
    public int hour;
    void Start()
    {
        LoadRelojTimer();
    }
    public void SaveRelojTimer() //Se utiliza para poder guardar la información del jugador al salir de la escena de Cultivos
    {
        PlayerPrefs.SetFloat("timer", timer); // Asegúrate de que gameTimer es una referencia a tu script de temporizador
        PlayerPrefs.SetInt("minute", minute);
        PlayerPrefs.SetInt("hour", hour);

        PlayerPrefs.Save();
    }
    public void LoadRelojTimer()
    {
        timer = PlayerPrefs.GetFloat("timer");
        minute = PlayerPrefs.GetInt("minute");
        hour = PlayerPrefs.GetInt("hour");
    }
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= 72)
        {
            minute = minute + 12;
            if (minute >= 60)
            {
                minute = minute - 60;
                hour = hour + 1;
            }
            hour = hour + 1;
            if (hour >= 23)
            {
                hour = 0;
            }
            timer = 0;
        }

        timerText.text = hour + " : " + minute;
    }
}
