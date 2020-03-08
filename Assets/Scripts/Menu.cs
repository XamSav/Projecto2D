using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Slider volumen;
    private void Awake()
    {
        volumen.value = PlayerPrefs.GetFloat("Volumen");
    }
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("Volumen", volumen.value);
        PlayerPrefs.Save();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
