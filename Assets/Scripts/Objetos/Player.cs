using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int _hits = 7;
    private Move _move;
    private Animator _animator;
    [SerializeField]
    private GameObject _axe;
    private int controller;
    private float secondsCounter = 0;
    private float secondsToCount = 1;
    [SerializeField]
    private Transform _axepoint_down;
    [SerializeField]
    private Transform _axepoint_down_rigth;
    [SerializeField]
    private Transform _axepoint_down_left;
    [SerializeField]
    private Transform _axepoint_up;
    [SerializeField]
    private Transform _axepoint_up_rigth;
    [SerializeField]
    private Transform _axepoint_up_left;
    [SerializeField]
    private Transform _axepoint_left;
    [SerializeField]
    private Transform _axepoint_rigth;
    [SerializeField]
    private Vector2 _movement;
    private Transform _positionaxe;
    GameObject hijo = null;

    void Awake()
    {
        //chestBool = GetComponent<ChestVillage>();
        controller = PlayerPrefs.GetInt("Controller");
        _move = GetComponent<Move>();
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Magnitude", _movement.magnitude);
    }
    void Update()
    {
        if (hijo != null)
        {
            hijo.GetComponent<Axe_Attack>().transform.position = _positionaxe.position;
            Debug.Log(_positionaxe);
        }
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
            }
        }
        if ((Input.GetKeyDown(KeyCode.K) || Input.GetButton("Fire1")) && ChestVillage.GetSword)
        {
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                //Solo Altura
                if (_movement.x == 0)
                {//Arriba
                    if (_movement.y == 1)
                    {
                        hijo = Instantiate(_axe, _axepoint_up.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_up;
                    }//Abajo
                    if (_movement.y == -1)
                    {
                        hijo = Instantiate(_axe, _axepoint_down.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_down;
                    }
                    if (_movement.y == 0)
                    {
                        hijo = Instantiate(_axe, _axepoint_down.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = 0;
                        hijo.GetComponent<Axe_Attack>()._movement.y = -1;
                        _positionaxe = _axepoint_down;
                    }
                }
                //Derecha
                if (_movement.x == 1)
                {//Arriba
                    if (_movement.y == 1)
                    {
                        hijo = Instantiate(_axe, _axepoint_up_rigth.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_up_rigth;
                    }//Abajo
                    if (_movement.y == -1)
                    {
                        hijo = Instantiate(_axe, _axepoint_down_rigth.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_down_rigth;
                    }
                    if (_movement.y == 0)
                    {
                        hijo = Instantiate(_axe, _axepoint_rigth.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_rigth;
                    }
                }
                //Izquierda
                if (_movement.x == -1)
                {//Arriba
                    if (_movement.y == 1)
                    {
                        hijo = Instantiate(_axe, _axepoint_up_left.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_up_left;
                    }//Abajo
                    if (_movement.y == -1)
                    {
                        hijo = Instantiate(_axe, _axepoint_down_left.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_down_left;
                    }
                    if (_movement.y == 0)
                    {
                        hijo = Instantiate(_axe, _axepoint_left.position, Quaternion.identity) as GameObject;
                        hijo.GetComponent<Axe_Attack>()._movement.x = _animator.GetFloat("Horizontal");
                        hijo.GetComponent<Axe_Attack>()._movement.y = _animator.GetFloat("Vertical");
                        _positionaxe = _axepoint_left;
                        //hijo.transform.parent = this.transform;
                    }
                }
            }
            
        }
        secondsCounter += Time.deltaTime;

    }
}
