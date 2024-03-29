﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Attack : MonoBehaviour
{

    private Animator _animatoraxe;
    public Vector2 _movement;
    public Vector3 positionaxe;
    private void Awake()
    {
        _animatoraxe = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        _animatoraxe.SetFloat("Vertical", _movement.y);
        _animatoraxe.SetFloat("Horizontal", _movement.x);
    }
}
