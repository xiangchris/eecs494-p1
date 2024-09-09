using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 4;
    static public bool player_control = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        if (player_control)
        {
            Vector2 currentInput = GetInput();
            rb.velocity = currentInput * movementSpeed;
        }
    }

    Vector2 GetInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horizontalInput) > 0.0f)
            verticalInput = 0.0f;
        return new Vector2 (horizontalInput, verticalInput);
    }
}
