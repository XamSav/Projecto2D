using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestVillage : MonoBehaviour
{
    public Animator chestOpens;
    private bool openInteraction;
    public GameObject itemloot;
    public static bool GetSword;
    private int controller;
    //public GameObject alert;

    private void Awake()
    {
        controller = PlayerPrefs.GetInt("Controller");
        GetSword = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (chestOpens.GetBool("ChestKey") == true && openInteraction == true)
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
            GetSword = true;
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
