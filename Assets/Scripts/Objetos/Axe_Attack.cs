using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Attack : MonoBehaviour
{

    private Animator _animatoraxe;
    private GameObject player;
    public Vector2 _movement;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _animatoraxe = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        _animatoraxe.SetFloat("Vertical", _movement.y);
        _animatoraxe.SetFloat("Horizontal", _movement.x);
    }
}
