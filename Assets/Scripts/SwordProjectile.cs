using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

    // Start movement of projectiles
    public void StartMovement(Vector3 pos)
    {
        gameObject.SetActive(true);
        transform.position = pos;
        transform.eulerAngles = new Vector3(0f, 0f, (float)ArrowKeyMovement.getDirection());
        rb.velocity = Utility.GetFacingVector() * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
            gameObject.SetActive(false);
    }
}
