using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupWalkie : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject walkie;
    [SerializeField] GameObject itself;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject script;
    [SerializeField] GameObject stuff; //Stuff is the card and the walkie talkie 


    private bool showGUI;
    private bool activated =false;
    Rect rect = new Rect(Screen.width / 2, Screen.height / 2, 200, 25);
    public bool inTrigger;


    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showGUI = true;
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        showGUI = false;
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        var enemyAi = enemy.GetComponent<EnemyAi>();

        if (Input.GetKeyDown("e") && inTrigger == true)
        {
            walkie.SetActive(true);
            
            //Teleports the enemy to the end of the hallway
            enemyAi.agent.Warp(new Vector3(12, 1, -26));
            activated = true;
            showGUI = false;

            //Triggers the flag for allowing the player to open the door
            script.GetComponent<FirstDoor>().setCard();

            //makes the card and walkie talkie disappear from the floor
            stuff.SetActive(false);

            StartCoroutine(Wait());

        }
        OnGUI();
    }
    void OnGUI()
    {
        if(showGUI && !activated)
        {
            GUI.Box(rect, "pickup card and walkie-talkie?");
        }
        if (activated)
        {
            GUI.Box(rect, "press shift to sprint");
        }
    }
    IEnumerator Wait() //function to deactive the sprint UI after 2 seconds
    {
        yield return new WaitForSeconds(2);
        activated = false;
        itself.SetActive(false);
        
        
    }

}
