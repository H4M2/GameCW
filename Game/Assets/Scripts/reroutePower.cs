using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reroutePower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] gameController gameScript;
    [SerializeField] GameObject playerFlashlight;
    [SerializeField] EnemyAi enemyScript;


    public Text prompt;
    public AudioSource ambient;

    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

        prompt.text = "Reroute power?";

        if (Input.GetKeyUp("e"))
        {
            
            gameScript.generator = true;
            playerFlashlight.SetActive(true);
            //enemyScript.sightRange = 10f;
            enemyScript.agent.Warp(new Vector3(30, 0, 0));

            ambient.enabled = false;

            prompt.text = "";
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.text = "";
    }
}
