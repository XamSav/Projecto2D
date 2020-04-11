using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Radio : MonoBehaviour
{
    public int Nivel = 0;

    public delegate void _Entrar(int Nivel);
    public static event _Entrar Entrar;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Entrar.Invoke(Nivel);
            Debug.Log("Entro el jugador");
        }
    }
    
}
