using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontalInput", rb.velocity.x);
        animator.SetFloat("verticalInput", rb.velocity.y);

        if(rb.velocity == Vector3.zero)
            animator.speed = 0.0f;
        else
            animator.speed = 1.0f;
    }
}
