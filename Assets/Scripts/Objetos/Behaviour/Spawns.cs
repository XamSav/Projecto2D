using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawns : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_a;
    [SerializeField]
    private GameObject _enemy_b;
    /*[SerializeField]
    private Transform _pointSpawn;*/
    [SerializeField]
    private bool _select;
    [SerializeField]
    private int _MaxRounds = 2;
    [SerializeField]
    private int _EnemysXRound = 2;
    private void Entro(int nivel)
    {
        StartCoroutine(Spawning());
    }
    private int _NumberRounds = 0;
    private void OnEnable()
    {
        Radio.Entrar += Entro;
            
    }
    IEnumerator TimeSpawn()
    {
        yield return new WaitForSeconds(10);
        if (_NumberRounds <= _MaxRounds)
        {
            StartCoroutine(Spawning());
        }
    }
    IEnumerator Spawning()
    {
        for (int a = 0; a < _EnemysXRound; a++) {
            Debug.Log("Corrutina Ok");
            switch (_select)
            {
                case true:
                    Instantiate(_enemy_a, transform.position, Quaternion.identity);
                    break;
                case false:
                    Instantiate(_enemy_b);
                    break;
            }
            
            yield return new WaitForSeconds(2);
        }
        _NumberRounds++;
        StartCoroutine(TimeSpawn());
    }
}
