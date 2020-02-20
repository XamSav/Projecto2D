using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hits = 7;

    private Move _move;
    void Awake()
    {
        _move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            _move.move(new Vector2(-1, 1));
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                _move.move(new Vector2(1, 1));
            }
            else
            {
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    _move.move(new Vector2(-1, -1));
                }
                else {
                    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                    {
                        _move.move(new Vector2(1, -1));
                    }
                    else {
                        if (Input.GetKey(KeyCode.W))
                        {
                            _move.move(new Vector2(0, 1));
                        }
                        if (Input.GetKey(KeyCode.S))
                        {
                            _move.move(new Vector2(0, -1));
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            _move.move(new Vector2(1, 0));
                        }
                        if (Input.GetKey(KeyCode.A))
                        {
                            _move.move(new Vector2(-1, 0));
                        }
                    }
                }
            }

        }
    }
}
