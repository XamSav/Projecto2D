using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private Vector2 _dir;
    [SerializeField]
    private float _velM;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void move()
    {
        _rb.MovePosition(new Vector3(transform.position.x + _dir.x * Time.deltaTime * _velM, transform.position.y + _dir.y * Time.deltaTime * _velM, 0));
    }
    public void move(Vector3 newdir)
    {
        _rb.MovePosition(new Vector3(transform.position.x + newdir.x * Time.deltaTime * _velM, transform.position.y + newdir.y * Time.deltaTime * _velM, 0));
    }
}
