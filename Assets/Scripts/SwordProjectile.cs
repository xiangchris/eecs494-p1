using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordProjectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    Vector3 setDirection()
    {
        Vector3 dir = Vector3.zero;
        switch (ArrowKeyMovement.getDirection())
        {
            case Utility.Facing.North:
                dir.y = 1f;
                break;
            case Utility.Facing.East:
                dir.x = 1f;
                break;
            case Utility.Facing.West:
                dir.x = -1f;
                break;
            default:
                dir.y = -1f;
                break;
        }
        return dir;
    }

    public void StartMovement(Vector3 pos)
    {
        gameObject.SetActive(true);
        transform.rotation = Quaternion.identity;
        transform.Rotate(0f, 0f, (float)ArrowKeyMovement.getDirection(), Space.World);
        rb.velocity = setDirection() * speed;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
            gameObject.SetActive(false);
    }
}
