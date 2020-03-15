using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Move _move;
    private void Awake()
    {
        _move = GetComponent<Move>();
    }
    private void FixedUpdate()
    {
        _move.move();
    }
}
