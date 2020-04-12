using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBlock : MonoBehaviour
{
    public Button[] buton = new Button [5];
    private bool button_press;
    public Animator slimeblock;
    [SerializeField]
    private int ArraySize;
    private int controller;


    private void Awake()
    {
        controller = PlayerPrefs.GetInt("Controller");
        slimeblock = GetComponent<Animator>();
        int ArraySize = buton.Length;
    }
    private void OnEnable()
    {
        for (int i = 0; i < ArraySize; i++)
        {
            buton[i].OnClick += OpenSlimeBlock;
        }         
    }
    private void OpenSlimeBlock()
    {

        if (button_press == true && slimeblock.GetBool("Open") == false)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            slimeblock.SetBool("Open", true);
        }
        else
        {
            if (button_press == true && slimeblock.GetBool("Open") == true)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                slimeblock.SetBool("Open", false);
            }
        }
    }
    private void FixedUpdate()
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
