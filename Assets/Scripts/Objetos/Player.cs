using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private int _hits = 7;
    private Move _move;
    private Animator _animator;
    //private Animator _animatoraxe;
    [SerializeField]
    private GameObject _axe;
    private int controller;
    private float secondsCounter = 0;
    private float secondsToCount = 1;
    /*[SerializeField]
    private Transform _axepoint;*/
    [SerializeField]
    private Vector2 _movement;
    private float x;
    private float y;
    void Awake()
    {
        controller = PlayerPrefs.GetInt("Controller");
        _move = GetComponent<Move>();
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        //_animatoraxe = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            _hits--;
            Debug.Log("Vidas restantes; " + _hits);
        }
    }
    private void Movement()
    {
        x = _movement.x;
        y = _movement.y;
        PlayerPrefs.SetFloat("DirHorizontal", x);
        PlayerPrefs.SetFloat("DirVertical", y);
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Magnitude", _movement.magnitude);
    }
    void Update()
    {
        if (_hits == 0)
        {
            Destroy(this.gameObject);
        }
        controller = PlayerPrefs.GetInt("Controller");

        if (controller == 0)
        {
            _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            Movement();
            _move.move(_movement.normalized);
        }
        else if(controller == 1)
        {
            //Up-Left
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                _movement = new Vector2(-1, 1);
                Movement();
                _move.move(_movement.normalized);
            }
            else
            {
                //Up-Right
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    _movement = new Vector2(1, 1);
                    Movement();
                    _move.move(_movement.normalized);
                }
                else
                {
                    //Down-Left
                    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                    {
                        _movement = new Vector2(-1, -1);
                        Movement();
                        _move.move(_movement.normalized);
                    }
                    else
                    {
                        //Down-Right
                        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                        {
                            _movement = new Vector2(1, -1);
                            Movement();
                            _move.move(_movement.normalized);
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.W))
                            {
                                _movement = new Vector2(0, 1);
                                Movement();
                                _move.move(Vector2.up);
                            }
                            if (Input.GetKey(KeyCode.S))
                            {
                                _movement = new Vector2(0, -1);
                                Movement();
                                _move.move(Vector2.down);
                            }
                            if (Input.GetKey(KeyCode.D))
                            {
                                _movement = new Vector2(1, 0);
                                Movement();
                                _move.move(Vector2.right);
                            }
                            if (Input.GetKey(KeyCode.A))
                            {
                                _movement = new Vector2(-1, 0);
                                Movement();
                                _move.move(Vector2.left);
                            }
                        }
                    }
                }
                PlayerPrefs.SetFloat("DirVertical", _movement.y);
                PlayerPrefs.SetFloat("DirHorizontal", _movement.x);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                GameObject hijo = Instantiate(_axe/*, _axepoint*/) as GameObject;
                hijo.transform.parent = this.transform;
                hijo.transform.position = this.transform.position;
            }
        }
        secondsCounter += Time.deltaTime;

    }
}
