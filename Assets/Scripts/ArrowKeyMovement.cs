using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    public enum FacingDirection
    {
        North,
        East,
        South,
        West
    }

    Rigidbody rb;
    private float gridSize = 0.5f;

    public float movementSpeed = 4;
    static public bool player_control = true;
    public static FacingDirection facingDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        if (player_control)
        {
            Vector2 input = GetInput();
            GridAlign(ref input);

            facingDirection = (input.x > 0) ? FacingDirection.East : (input.x < 0) ? FacingDirection.West : facingDirection;
            facingDirection = (input.y > 0) ? FacingDirection.North : (input.y < 0) ? FacingDirection.South : facingDirection;

            rb.velocity = input * movementSpeed;
        }
    }

    Vector2 GetInput()
    {     
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(verticalInput) > 0.0f)
            horizontalInput = 0.0f;

        return new Vector2 (horizontalInput, verticalInput);
    }

    private void GridAlign(ref Vector2 input)
    {
        Vector3 pos = transform.position;
        float offsetX = pos.x % gridSize;
        float offsetY = pos.y % gridSize;

        if (input.x != 0.0f && offsetY != 0.0f)
            transform.position = new Vector3(pos.x, AlignCoordinate(pos.y, offsetY), pos.z);
        if (input.y != 0.0f && offsetX != 0.0f)
            transform.position = new Vector3(AlignCoordinate(pos.x, offsetX), pos.y, pos.z);
    }
    private float AlignCoordinate(float position, float offset)
    {
        return (offset < gridSize / 2f) ? (position - offset) : (position + (gridSize - offset));
    }
}
