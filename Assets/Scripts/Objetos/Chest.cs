using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestOpens;
    private bool openInteraction;
    public GameObject itemloot;
    //public GameObject alert;
    public GameObject Lever;
    private int controller;
    private void Awake()
    {
        controller = PlayerPrefs.GetInt("Controller");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(chestOpens.GetBool("ChestKey") == true && openInteraction == true)
        {
            /*GameObject alertOn = (GameObject)Instantiate(alert, transform.position, Quaternion.identity);
            Destroy(alertOn, 1.5f);*/
            Debug.Log("Item already claimed.");
        }
        else if (openInteraction == true)
        {
            chestOpens.SetBool("ChestKey", true);
            GameObject clone = (GameObject)Instantiate(itemloot, transform.position, Quaternion.identity);
            Destroy(clone, 1.5f);
            Lever.SetActive(true);
        }        
    }
    private void FixedUpdate()
    {
        controller = PlayerPrefs.GetInt("Controller");
        if (controller == 1)
        {
            openInteraction = Input.GetKeyDown(KeyCode.E);
        }
        else if (controller == 0)
        {
            openInteraction = Input.GetButton("Use");
        }
    }
}
