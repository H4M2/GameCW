using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public AudioSource clip;
    public GameObject enemy;

    public bool isAngry;
    bool toggle;



    // Start is called before the first frame update
    void Start()
    {
        //clip.Play();
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        isAngry = enemy.GetComponent<EnemyAi>().angry;
        
        clip.loop = isAngry;
        if (isAngry && !toggle)
        {
            clip.Play();
            toggle = true;
        }
        if(toggle && !isAngry)
        {
            clip.Stop();
            toggle = false;
        }

        
    }
}
