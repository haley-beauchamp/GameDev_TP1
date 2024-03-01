using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if (collision.GetComponent<enemyHealth>() != null)
            {
                int eHealth = collision.GetComponent<enemyHealth>().eHealth;
                eHealth = eHealth - damage;
                collision.GetComponent<enemyHealth>().eHealth = eHealth;
            }
        }
    }
}
