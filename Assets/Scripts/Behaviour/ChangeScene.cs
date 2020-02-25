using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int level = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hey!");
        SceneManager.LoadScene(level);
    }
}
