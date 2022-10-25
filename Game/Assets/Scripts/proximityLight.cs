using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximityLight : MonoBehaviour
{
    
    //[SerializeField] float detectionRange = 10f;
    [SerializeField] float timer = 0f;
    Light myLight;
    [SerializeField] bool isClose;
    [SerializeField] bool flickerClose;
    Transform enemyVar;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        enemyVar = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        isClose = false;
        flickerClose = false;

        if (Vector3.Distance(enemyVar.position, transform.position) <= 5f)
        {
            isClose = true;
        }
        if (Vector3.Distance(enemyVar.position, transform.position) <= 10f)
        {
            flickerClose = true;
        }
        TurnOff();
        Flicker();
    }
    void TurnOff()
    {
        if (flickerClose)
        {
            if (isClose)
            {

                myLight.intensity = 0;
            }
        }
    }
    void Flicker()
    {
        if (!isClose)
        {

            if (flickerClose)
            {

                timer += Time.deltaTime;
                if (timer < 0.5)
                {
                    myLight.intensity = 0;
                }
                else
                {
                    myLight.intensity = 1;
                    if (timer > 1)
                    {
                        timer = 0;
                    }
                }
            }
            else
            {
                myLight.intensity = 1;
            }
        }
    }
}
