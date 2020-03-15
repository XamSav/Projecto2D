using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : MonoBehaviour
{
    private int _hits;
    [SerializeField]
    private Transform _player;
    private float _alfa;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Mirar()
    {
        _alfa = Mathf.Atan2(_player.position.y - transform.position.y, _player.position.x - transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(_alfa, Vector3.forward);
    }
    void Update()
    {
        Mirar();
        //Right
        if (_alfa <= 30 && _alfa >= -30)
        {
            _animator.SetFloat("Horizontal_B", 1);
            _animator.SetFloat("Vertical_B", 0);
        }
        //Up-Right
        if (_alfa >= 31 && _alfa <= 69)
        {
            _animator.SetFloat("Horizontal_B", 1);
            _animator.SetFloat("Vertical_B", 1);
        }
        //Up
        if (_alfa <=110 && _alfa >= 70)
        {
            _animator.SetFloat("Horizontal_B", 0);
            _animator.SetFloat("Vertical_B", 1);
        }
        //Up-Left
        if (_alfa >= 111 && _alfa <= 159)
        {
            _animator.SetFloat("Horizontal_B", -1);
            _animator.SetFloat("Vertical_B", 1);
        }
        //Left
        if (_alfa >=160 || _alfa <= -160)
        {
            _animator.SetFloat("Horizontal_B", -1);
            _animator.SetFloat("Vertical_B", 0);
        }
        //Down
        if(_alfa >= -110 && _alfa <= -70)
        {
            _animator.SetFloat("Horizontal_B", 0);
            _animator.SetFloat("Vertical_B", -1);
        }
        //Down-Left
        if (_alfa <= -111 && _alfa >= -159)
        {
            _animator.SetFloat("Horizontal_B", -1);
            _animator.SetFloat("Vertical_B", -1);
        }
        //Down-Right
        if (_alfa <= -31 && _alfa >= -69)
        {
            _animator.SetFloat("Horizontal_B", 1);
            _animator.SetFloat("Vertical_B", -1);
        }
        if(_hits == 3)
        {
            Destroy(this.gameObject);
        }
    }
}
