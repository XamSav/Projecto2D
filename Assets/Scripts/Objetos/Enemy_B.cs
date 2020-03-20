using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : MonoBehaviour
{
    private int _hits = 0;
    [SerializeField]
    private Transform _player;
    private float _alfa;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Vidas restantes del enemigo; " + _hits);

        if (col.gameObject.tag == "Axe")
        {
            _hits++;
            Debug.Log("Vidas restantes del enemigo; " + _hits);
        }
    }
    void Update()
    {
        //Mirar();
        Vector3 _movement = new Vector3(_player.position.x - transform.position.x, _player.position.y - transform.position.y, 0);
        _animator.SetFloat("Horizontal_B", _movement.x);
        _animator.SetFloat("Vertical_B", _movement.y);
        if(_hits == 3)
        {
            Destroy(this.gameObject);
        }
    }
}
