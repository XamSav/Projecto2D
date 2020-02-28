using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    private GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("camara enable");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    
}
