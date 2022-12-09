using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 50f;
   private GameObject maze;

    void Start()
    {
        maze = GameObject.Find("MazeGenerator");
    }

    public void TakeDamage (float amount)
   {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
   }

   void Die () {
        Destroy(gameObject);
        maze.GetComponent<MazeGenerator>().enemydie();
    }
}
