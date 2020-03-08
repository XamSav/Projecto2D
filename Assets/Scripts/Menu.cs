using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Menu : MonoBehaviour
{
    
    [SerializeField]
    private Slider volumen;
    private bool _controlleroption = true;
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
    public void HandleInputData(int val)
    {
        //Mando
        if (val == 1)
        {
            _controlleroption = true;
            Debug.Log(_controlleroption);
            

        }
        //PC
        if (val == 0)
        {
            _controlleroption = false;
            Debug.Log(_controlleroption);
            
        }
    }
}
