using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level2Trigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;

    public Text prompt;

    public gameController gameControllerScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyAi>().agent.Warp(new Vector3(36, 1, 71));
            enemy.GetComponent<EnemyAi>().walkPointSet = false;

            gameControllerScript.checkpoint = this.transform.position;
        }
    }
}
