using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{

    public Animator button_anim;
    public event Action OnClick = delegate { };
    private bool button_press;

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
        button_press = Input.GetKeyDown(KeyCode.E);
    } 
}
