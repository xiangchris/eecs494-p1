using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public int health;
    public float kb = 5;
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
        if (health > 0)
        {
            Vector3 dir = CalculateKBDirection(transform.position - otherPos);
            rb.velocity = dir * kb;
            StartCoroutine(StopCharacterAfterKnockback());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    Vector3 CalculateKBDirection(Vector3 diff)
    {
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            diff.y = 0;
        else
            diff.x = 0;
        diff.Normalize();
        return diff;
    }

    IEnumerator StopCharacterAfterKnockback()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }
}
