using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestOpens;
    private bool openInteraction;
    public GameObject itemloot;
    public GameObject alert;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(chestOpens.GetBool("ChestKey") == true && openInteraction == true)
        {
            GameObject alertOn = (GameObject)Instantiate(alert, transform.position, Quaternion.identity);
            Destroy(alertOn, 1.5f);
        }
        else if (openInteraction == true)
        {
            chestOpens.SetBool("ChestKey", true);
            GameObject clone = (GameObject)Instantiate(itemloot, transform.position, Quaternion.identity);
            Destroy(clone, 1.5f);
        }        
    }
    private void FixedUpdate()
    {
            openInteraction = Input.GetKeyDown(KeyCode.E);        
    }
}
