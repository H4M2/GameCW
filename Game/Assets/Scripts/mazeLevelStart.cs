using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeLevelStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        enemy.GetComponent<EnemyAi>().agent.Warp(new Vector3(54, 1, 24));
        enemy.GetComponent<EnemyAi>().walkPointSet = false;
    }
}
