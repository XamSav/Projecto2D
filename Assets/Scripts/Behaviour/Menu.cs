using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Slider volumen;
    public Toggle subtitulos;
    private void Awake()
    {
        volumen.value = PlayerPrefs.GetFloat("Volumen");
        subtitulos.isOn = PlayerPrefs.GetInt("Subtitulos") == 1 ? true : false;
    }
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("Volumen", volumen.value);
        int k = subtitulos.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Subtitulos", k);

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
}
