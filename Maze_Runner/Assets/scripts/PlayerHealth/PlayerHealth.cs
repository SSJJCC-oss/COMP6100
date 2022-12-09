using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage ()
   {
        //Decrements the health every second an individual zombie attacks
        health -= 1 * Time.deltaTime;  

        if(health <= 0f)
        {
            Die();
        }
   }

   void Die () {
        //Loads the scene that displays "GAME OVER"
        SceneManager.LoadScene(4);
   }

    public float GetHealth()
    {
        return health;
    }
}
