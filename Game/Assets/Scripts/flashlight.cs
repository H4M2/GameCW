using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    float timer;
    [SerializeField] Light myLight;
    public float normalIntensity = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRay();
    }
    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.collider.tag == "Enemy")
        {
            timer += Time.deltaTime;
            if (timer < 0.2)
            {
                myLight.intensity = 0;
            }
            else
            {
                myLight.intensity = normalIntensity;
                if (timer > 0.4)
                {
                    timer = 0;
                }
            }
        }
        else
        {
            myLight.intensity = normalIntensity;
        }
    }
}
