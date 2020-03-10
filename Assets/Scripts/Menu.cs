using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Menu : MonoBehaviour
{
    
    [SerializeField]
    private Slider volumen;
    [SerializeField]
    private Dropdown Controller;
    private void Awake()
    {
        volumen.value = PlayerPrefs.GetFloat("Volumen");
        Controller.value = PlayerPrefs.GetInt("Controller");
    }
    public void SaveOptions()
    {
        PlayerPrefs.SetInt("Controller", Controller.value);
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
