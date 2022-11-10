using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandler : MonoBehaviour
{
    //calls the the animation handler
    Animator _doorAnim;
    
    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("character_nearby", false);
    }

    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
}
