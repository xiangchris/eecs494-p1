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
        animator.SetFloat("horizontalInput", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("verticalInput", Input.GetAxisRaw("Vertical"));

        Flip();

        if(rb.velocity == Vector3.zero)
            animator.speed = 0.0f;
        else
            animator.speed = 1.0f;
    }

    void Flip()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Quaternion rotate = transform.rotation;
        if (input != 0)
            rotate.y = input > 0 ? 0 : input < 0 ? 180 : rotate.y;
        transform.rotation = rotate;
    }
}
