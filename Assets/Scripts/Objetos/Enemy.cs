using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Move _move;
    [SerializeField]
    private bool _aggro;

    float seconds;
    int randomdir;

    void Awake()
    {
        _move = GetComponent<Move>();
        seconds = 3;
        randomdir= Random.Range(0, 4);
    }

    void Update()
    {
        
        seconds -= Time.deltaTime;


        switch (randomdir)
        {
            case 0:
                _move.move(new Vector2(0, 1));
                break;
            case 1:
                _move.move(new Vector2(0, -1));
                break;
            case 2:
                _move.move(new Vector2(1, 0));
                break;
            case 3:
                _move.move(new Vector2(-1, 0));
                break;
        }
    }
}
