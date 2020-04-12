using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{

    public Animator button_anim;
    public event Action OnClick = delegate { };
    private bool button_press;
    private int controller;
    private void Awake()
    {
        controller = PlayerPrefs.GetInt("Controller");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnClick.Invoke();
        if (button_press == true && button_anim.GetBool("TurnsOn") == false)
        {
            button_anim.SetBool("TurnsOn", true);
        }
        else
        {
            if (button_press == true && button_anim.GetBool("TurnsOn") == true)
            {
                button_anim.SetBool("TurnsOn", false);
            }
        }
    }
    void FixedUpdate()
    {
        
        controller = PlayerPrefs.GetInt("Controller");
        if (controller == 1)
        {
             button_press = Input.GetKeyDown(KeyCode.E);
        }
        else if (controller == 0)
        {
             button_press = Input.GetButton("Use");
        }
    } 
}
