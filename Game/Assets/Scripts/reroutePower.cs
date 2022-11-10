using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reroutePower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] gameController gameScript;
    Rect rect = new Rect(Screen.width / 2, Screen.height / 2, 200, 25);
    bool showGUI = false;
    [SerializeField] GameObject playerFlashlight;
    [SerializeField] EnemyAi enemyScript;

    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        showGUI = true;
        if (Input.GetKeyUp("e"))
        {
            
            gameScript.generator = true;
            playerFlashlight.SetActive(true);
            //enemyScript.sightRange = 10f;
            enemyScript.agent.Warp(new Vector3(30, 0, 0));

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        showGUI = false;
    }

    private void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(rect, "Press E to reroute power");
        }
    }
}
