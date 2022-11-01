using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_script : MonoBehaviour
{
    //The player object
    GameObject player;
    Transform player_Transform;
    playerController playerScript = null;

    //Cameras
    [SerializeField] Camera hideCamera;
    Camera playerCamera;

    //GetEvent Controller
    GameObject gameController;

    float raylength = 2f;

    //object variables
    [SerializeField] bool isHiding;
    void Start()
    {
        //Player Variables
        player = GameObject.FindWithTag("Player");
        playerCamera = player.GetComponentInChildren<Camera>();
        player_Transform = player.GetComponent<Transform>();
        playerScript = player.GetComponent<playerController>();

        hideCamera.enabled = false;

        isHiding = false;
        gameController = GameObject.FindWithTag("GameController");

    }
    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;

        if (Physics.Raycast(player_Transform.position, player_Transform.TransformDirection(Vector3.forward), out hit, raylength) && !isHiding)
        {
            //Debug.Log("AYO");
            if (Input.GetKeyDown("e"))  
            {
                Debug.Log("yes?");
                hideCamera.enabled = true;
                playerCamera.enabled = false;

                Wait();
                
            }
   
        }
        if (Input.GetKeyDown("e") && isHiding)
        {
            Debug.Log("this isnt happening");
            hideCamera.enabled = false;
            playerCamera.enabled = true;

            Wait();
        }
    }
    IEnumerator Wait() //function to deactive the sprint UI after 2 seconds
    {
        yield return new WaitForSeconds(2);
        isHiding = !isHiding;


    }
}
