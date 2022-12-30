using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazeLevelStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;

    public Text prompt;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        enemy.GetComponent<EnemyAi>().agent.Warp(new Vector3(54, 1, 24));
        enemy.GetComponent<EnemyAi>().walkPointSet = false;

        StartCoroutine(objectiveText());


    }
    IEnumerator objectiveText()
    {
        prompt.text = "Find a way out";
        yield return new WaitForSeconds(2f);
        prompt.text = "";

    }
}
