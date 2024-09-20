using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public int health;
    public float kb;
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
        Vector3 diff = transform.position - otherPos;
        diff = new Vector3(1f, 1f, 0f) * Mathf.Max(diff.x, diff.y);
        diff.Normalize();
        rb.velocity = diff * kb;
        StartCoroutine(StopCharacterAfterKnockback());
    }

    IEnumerator StopCharacterAfterKnockback()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }
}
