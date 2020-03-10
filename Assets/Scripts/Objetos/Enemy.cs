using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Move _move;
    [SerializeField]
    private bool _aggro;
    private Animator _animator;
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
        _animator = GetComponent<Animator>();
        randomdir = Random.Range(0, 8);
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
                _animator.SetInteger("eState", 1);
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
                    case 4:
                        _move.move(new Vector2(-1, -1));
                        break;
                    case 5:
                        _move.move(new Vector2(-1, 1));
                        break;
                    case 6:
                        _move.move(new Vector2(1, 1));                       
                        break;
                    case 7:
                        _move.move(new Vector2(1, -1));                      
                        break;


                }
                _animator.SetInteger("eState", 0);
                seconds = 0;
                randomdir = Random.Range(0, 8);
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
