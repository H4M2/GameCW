using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximityLight : MonoBehaviour
{
    [SerializeField] Transform enemy = null;
    [SerializeField] float detectionRange = 6f;
    [SerializeField] float timer = 0f;
    Light myLight;
    [SerializeField] bool isClose;
    [SerializeField] bool flickerClose;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        isClose = false;
        flickerClose = false;

        if (Vector3.Distance(enemy.position, transform.position) <= 3f)
        {
            isClose = true;
        }
        if (Vector3.Distance(enemy.position, transform.position) <= detectionRange)
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
                if (timer < 1)
                {
                    myLight.intensity = 0;
                }
                else
                {
                    myLight.intensity = 1;
                    if (timer > 2)
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
