using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldKnock : MonoBehaviour
{
   /* private float timebtwKnock;
    public float startTimebtwKnock;

    public Transform knockPos;
    public LayerMask whatIsEnemy;
    public float knockRange;

    void Update()
    {
        if(timebtwKnock <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(knockPos.position, knockRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().GetKnocked();
                }

            }
            timebtwKnock = startTimebtwKnock;
        }
        else
        {
            timebtwKnock -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(knockPos.position, knockRange);
    }*/
}
