using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health = 50f;
    public bool die = false;

    Transform target;
    NavMeshAgent agent;
    Animator animator;
    GameObject playerCamera;
    GameObject maze;

    // Start is called before the first frame update
    void Start()
    {
        maze = GameObject.Find("MazeGenerator");
        playerCamera = GameObject.Find("Player Camera");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //set distance to player - enemy
        float distance = Vector3.Distance(target.position, transform.position);
        if(die != true){
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
            //attack target
            animator.SetBool("Attack", true);
            playerCamera.GetComponent<PlayerHealth>().TakeDamage();
            // face target
            FaceTarget();
            }
            else {
                animator.SetBool("Attack", false);
            }
        }             
    }

    void FaceTarget()
    {
        //get direction and turn enemy to face direction of player
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void TakeDamage (float amount)
   {
        health -= amount;
        if(health <= 0f)
        {
            Die();
            die = true;
        }
   }

   void Die () {
        //Uses the animation "Falling Back" that has been set using the animator and after 4 seconds destroys the dead zombie
        animator.SetBool("Die", true);
        Destroy(gameObject, 4);
        maze.GetComponent<MazeGenerator>().enemydie();
    }
}
