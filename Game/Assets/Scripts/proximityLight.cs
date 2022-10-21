using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximityLight : MonoBehaviour
{
    [SerializeField] Transform enemy = null;
    [SerializeField] float detectionRange = 5f;
    Light myLight;
    bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        isClose = false;

        if (Vector3.Distance(enemy.position, transform.position) <= detectionRange)
        {
            isClose = true;
            Debug.Log("test");
        }
        if (isClose)
        {
            myLight.intensity = 0;
        }
        else
        {
            myLight.intensity = 1;
        }
    }
}
