using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public int level;

    public static LevelManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        if (player.Length > 1)
            Destroy(player[1]);
       

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(this);

    }
}
