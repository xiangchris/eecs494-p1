using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    public static Rigidbody playerRigidbody;
    private float gridSize = 0.5f;
    private static Utility.Facing direction;

    public float movementSpeed = 4;
    static public bool playerControl = true;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        if (playerControl)
        {
            Vector2 input = GetInput();
            GridAlign(ref input);

            direction = (input.x > 0) ? Utility.Facing.East : (input.x < 0) ? Utility.Facing.West : direction;
            direction = (input.y > 0) ? Utility.Facing.North : (input.y < 0) ? Utility.Facing.South : direction;

            playerRigidbody.velocity = input * movementSpeed;
        }
    }

    public static Utility.Facing getDirection() {  return direction; }

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
        Vector2 pos = transform.position;
        float offsetX = pos.x % gridSize;
        float offsetY = pos.y % gridSize;

        if (input.x != 0.0f && offsetY != 0.0f)
            pos.y = AlignCoordinate(pos.y, offsetY);
        if (input.y != 0.0f && offsetX != 0.0f)
            pos.x = AlignCoordinate(pos.x, offsetX);
        transform.position = pos;
    }
    private float AlignCoordinate(float position, float offset)
    {
        return (offset < gridSize / 2f) ? (position - offset) : (position + (gridSize - offset));
    }
}
