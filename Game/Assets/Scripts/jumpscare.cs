using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public Rigidbody plant;
    public float thrust = 100f;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plant.AddForce(transform.right * thrust);
            Debug.Log("yes");
        }

    }
}
