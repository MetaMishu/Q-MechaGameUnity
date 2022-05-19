using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float maxAnimatorSpeed = 5.0f;



    // caching the components
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }



    void Update()
    
    {
        animator.SetFloat("Blend", rb.velocity.magnitude / maxAnimatorSpeed);
    }
}
