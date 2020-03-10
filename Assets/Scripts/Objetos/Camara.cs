using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    private GameObject player;
    [SerializeField]
    private bool bounds = true;

    [SerializeField]
    private Vector3 minCameraPos;
    [SerializeField]
    private Vector3 MaxCameraPos;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("camara enable");
    }

    private void FixedUpdate()
    {
        
       transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, MaxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, MaxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, MaxCameraPos.z));
        }
    }
    
}
