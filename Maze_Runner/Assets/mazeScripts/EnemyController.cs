using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Player Camera");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
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

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
