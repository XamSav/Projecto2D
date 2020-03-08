using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInXTime : MonoBehaviour
{
    [SerializeField]
    private float time = 0.5f;
    [SerializeField]
    private GameObject objectDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destroy");
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Hey!");
        Destroy(objectDestroy);
    }
}
