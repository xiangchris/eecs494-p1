using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public HasHealth health;
    public SpriteRenderer spriteRenderer;
    public float iFrameDuration = 3.0f;

    private bool iFrame = false;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" && !iFrame)
        {
            StartCoroutine(DamagePlayer());
        }
    }

    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(iFrameDuration);
    }
}
