﻿
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask levelLayer;
    public LayerMask playerLayer;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Checks
    public float sightRange;
    public bool playerInSightRange;
    public bool LOS;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        LOS = LineOfSight();
        if (!playerInSightRange) Patroling();
        if (playerInSightRange && !LOS) Patroling();
        if (playerInSightRange && LOS) ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    bool LineOfSight()
    {
        if (Physics.Linecast(transform.position, player.position, levelLayer))
        {
            return false;
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("no colides");
            return true;
        }
    }

    void Patroling()
    {
        Debug.Log("patrol");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, levelLayer))
            walkPointSet = true;
    }

    void ChasePlayer()
    {
        Debug.Log("chase");
        agent.SetDestination(player.position);
    }
}
