using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Move _move;
    [SerializeField]
    private bool _aggro;
    /*private Transform player;
    private float distance;
    private float howclose;*/

    float seconds;
    int randomdir;
    float wait;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        _move = GetComponent<Move>();
        //seconds = 3;
        randomdir = Random.Range(0, 4);
        seconds = 0;
        wait = 3;
        //howclose = 8;
    }

    void Update()
    {
        /*distance = Vector3.Distance(player.position, transform.position);
        if (distance <= howclose)
        {
            _aggro = true;
        }*/

        if(_aggro == false)
        {
            //seconds -= Time.deltaTime;
            seconds += Time.deltaTime;

            if (seconds >= wait)
            {
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
                seconds = 0;
                randomdir = Random.Range(0, 4);
            }
        }
        /*else
        {
            if(distance <= howclose)
            {
                transform.LookAt(player);
                GetComponent<RigidBody>().AddForce(transform.forward * _move);
            }
        } */       
    }
}
