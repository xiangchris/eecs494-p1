using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public int health;
    public float kb = 5;
    Rigidbody rb;

    public GameObject heart;
    public GameObject rupee;

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
            if (gameObject.tag == "enemy")
            {
                DropItem();
                gameObject.SetActive(false);
            }
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

    void DropItem()
    {
        int rand = Random.Range(0, 5);
        GameObject spawn;
        switch (rand)
        {
            case 1:
                spawn = heart;
                break;
            case 2:
                spawn = rupee;
                break;
            default:
                spawn = null;
                break;
        }
        if (spawn != null)
            Instantiate(spawn, transform.position, Quaternion.identity);
    }
}
