using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector2 setDirection()
    {
        Vector2 dir = Vector2.zero;
        float zRotate = 0f;
        switch (ArrowKeyMovement.getDirection())
        {
            case Utility.FacingDirection.North:
                zRotate = 180;
                dir.y = 1f;
                break;
            case Utility.FacingDirection.East:
                zRotate = 90;
                dir.x = 1f;
                break;
            case Utility.FacingDirection.West:
                zRotate = 270;
                dir.x = -1f;
                break;
            default:
                zRotate = 0f;
                dir.y = -1f;
                break;
        }
        transform.Rotate(0f, 0f, zRotate);
        return dir;
    }

    public void StartMovement(Vector3 pos)
    {
        transform.rotation = Quaternion.identity;
        rb.velocity = setDirection() * speed;
        transform.position = pos;
        gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
            gameObject.SetActive(false);
    }
}
