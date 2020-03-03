using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private int hits = 7;

    private Move _move;
    private Animator _animator;
    void Awake()
    {        
        _move = GetComponent<Move>();
    }
    private void Start()
    {
        _animator=GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Up-Left
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            _animator.SetInteger("State",6);
            _move.move(new Vector2(-1, 1).normalized);
        }
        else
        {
            //Up-Right
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                _animator.SetInteger("State",4);
                _move.move(new Vector2(1, 1).normalized);
            }
            else
            {
                //Down-Left
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    _animator.SetInteger("State",8);
                    _move.move(new Vector2(-1, -1));
                }
                else {
                    //Down-Right
                    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                    {
                        _animator.SetInteger("State",2);
                        _move.move(new Vector2(1, -1));
                    }
                    else {
                        if (Input.GetKey(KeyCode.W))
                        {
                            _animator.SetInteger("State",5);
                            _move.move(Vector2.up);
                        }
                        if (Input.GetKey(KeyCode.S))
                        {
                            _animator.SetInteger("State",1);
                            _move.move(Vector2.down);
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            _animator.SetInteger("State",3);
                            _move.move(Vector2.right);
                        }
                        if (Input.GetKey(KeyCode.A))
                        {
                            _animator.SetInteger("State", 7);
                            _move.move(Vector2.left);
                        }
                      /*  if (!Input.anyKey){
                            _animator.SetInteger("State", 0);
                        }*/
                    }
                }
            }

        }
       
    }
}
