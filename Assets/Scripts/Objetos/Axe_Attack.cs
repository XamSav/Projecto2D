using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Attack : MonoBehaviour
{

    private Animator _animatoraxe;
    private Vector2 _movement;
    private void Awake()
    {
        _animatoraxe = GetComponent<Animator>();
        _movement =new Vector2 (PlayerPrefs.GetFloat("DirVertical"), PlayerPrefs.GetFloat("DirHorizontal"));
    }
    void FixedUpdate()
    {
        Debug.Log("Pulsaste Espacio");
        _movement = new Vector2(PlayerPrefs.GetFloat("DirVertical"), PlayerPrefs.GetFloat("DirHorizontal"));
        _animatoraxe.SetFloat("Vertical", _movement.y);
        _animatoraxe.SetFloat("Horizontal", _movement.x);
    }
}
