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

        float offsetX = transform.position.x % 0.5f;
        float offsetY = transform.position.y % 0.5f;

        if (Mathf.Abs(horizontalInput) > 0.0f)
            verticalInput = 0.0f;

        if (verticalInput != 0.0f && offsetX != 0.0f)
        {
            if (offsetX < 0.25f)
                offsetX = transform.position.x - offsetX;
            else
                offsetX = transform.position.x + (0.5f - offsetX);
            transform.position = new Vector3(offsetX, transform.position.y, transform.position.z);
        }
        else if (horizontalInput != 0.0f && offsetY != 0.0f)
        {
            if(offsetY < 0.25f)
                offsetY = transform.position.y - offsetY;
            else offsetY = transform.position.y + (0.5f - offsetY);
            transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
        }
        
        return new Vector2 (horizontalInput, verticalInput);
    }
}
