using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //private int hits = 7;
    public Menu menu;
    private Move _move;
    private Animator _animator;
    [SerializeField]
    private GameObject _axe;
    private int controller;
    private float secondsCounter = 0;
    private float secondsToCount = 1;
    void Awake()
    {
        _move = GetComponent<Move>();
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void HandleInputData(int val)
    {
            controller = val;
    }

    void Update()
    {
        if (controller == 0)
        {
            Debug.Log("Hey!");
            Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Magnitude", _movement.magnitude);
            _move.move(_movement.normalized);
        }
        else
        {
            Debug.Log("Hey!");
            Vector3 _movement = new Vector3(Input.GetAxis("HorizontalS"), Input.GetAxis("VerticalS"), 0.0f);
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Magnitude", _movement.magnitude);
            _move.move(_movement);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                GameObject hijo = Instantiate(_axe) as GameObject;
                hijo.transform.parent = this.transform;
                hijo.transform.position = this.transform.position;
            }
        }
        secondsCounter += Time.deltaTime;
    }
}
