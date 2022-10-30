using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandler : MonoBehaviour
{
    Animator _doorAnim;
    // Start is called before the first frame update
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
    void Update()
    {
        
    }
}
