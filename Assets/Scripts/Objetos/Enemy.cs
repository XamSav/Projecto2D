using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _enemylocation;
    private Transform _player;
    private Move _move;
    [SerializeField]
    private bool _aggro;
    private Animator _animator;
    public Rigidbody2D enemyRigidBody;
    public Vector3 moveDirection;

    [SerializeField]
    private int _hits = 0;
    float seconds;
    int randomdir;
    float wait;

    void Awake()
    {
        _move = GetComponent<Move>();
        _animator = GetComponent<Animator>();
        randomdir = Random.Range(0, 8);
        seconds = 0;
        wait = 3;

        _enemylocation = this.transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if(_aggro == false)
        {
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
            if (Vector3.Distance(_enemylocation.position, _player.position) <= 5)
            {
                _aggro = true;
            }
        }
        else
        {
            Vector3 _facing = new Vector3(_player.position.x - transform.position.x, _player.position.y - transform.position.y, 0).normalized;
            _move.move(_facing);
        }
        if (_hits == 4)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Axe")
        {
            _hits++;
            Debug.Log("Vidas restantes del enemigo; " + _hits);
        }
        /*if (col.gameObject.tag == "Shield")
        {
            moveDirection = enemyRigidBody.transform.position - col.transform.position;
            enemyRigidBody.AddForce(moveDirection * -500.0f);
        }*/
    }
    /*public void TakeDamage(int damage)
{
   currentHealth -= damage;
   if (currentHealth <= 0)
   {
       Die();
   }
}
void Die()
{
   Debug.Log("Enemy died!");

   //Die Animation

   //Disable Enemy
}*/
}
