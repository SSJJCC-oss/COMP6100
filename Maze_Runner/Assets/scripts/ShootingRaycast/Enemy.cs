using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 50f;
   private GameObject maze;
   Animator animator;

    void Start()
    {
        maze = GameObject.Find("MazeGenerator");
        animator = GetComponentInChildren<Animator>();
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
        animator.SetBool("Die", true);
        Destroy(gameObject, 4);
        maze.GetComponent<MazeGenerator>().enemydie();
    }
}
