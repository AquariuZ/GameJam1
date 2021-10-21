using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBridge : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //whats needed for the bridge to rotate (sacrifices, altars, etc)
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
