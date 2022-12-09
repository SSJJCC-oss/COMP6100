using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 2000f;

    public void TakeDamage()
    {
        health -= 1 * Time.deltaTime;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("die");
    }
}
