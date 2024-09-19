using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public int health;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int h)
    {
        health = h;
    }

    public void AddHealth(int h)
    {
        health += h;
    }

    public void TakeDamage(Vector3 otherPos)
    {
        AddHealth(-1);
        Vector3 aThing = transform.position - otherPos;
        rb.velocity = Vector3.zero;

    }
}
