using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazeLevelStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;

    public Text prompt;

    public AudioSource ambient;

    public gameController gameControllerScript;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyAi>().agent.Warp(new Vector3(54, 1, 24));
            enemy.GetComponent<EnemyAi>().walkPointSet = false;

            ambient.enabled = true;

            StartCoroutine(objectiveText());
            gameControllerScript.checkpoint = this.transform.position;
        }
            
    }
    IEnumerator objectiveText()
    {
        prompt.text = "Find a way out";
        yield return new WaitForSeconds(3f);
        prompt.text = "";

    }
}
