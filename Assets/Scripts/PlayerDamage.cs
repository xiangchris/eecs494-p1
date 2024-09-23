using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    HasHealth health;
    public float iFrameDuration = 3.0f;

    public SpriteRenderer sr;
    bool iFrame = false;

    void Start()
    {
        health = GetComponent<HasHealth>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" && !iFrame)
        {
            StartCoroutine(FlashSprite());
            iFrame = true;
            health.TakeDamage(collision.gameObject.transform.position);
            StartCoroutine(DamagePlayer());

            if (health.GetHealth() <= 0)
            {
                SceneManager.LoadScene("ZeldaTemplate");
            }
        }
    }

    IEnumerator DamagePlayer()
    {
        ArrowKeyMovement.playerControl = false;
        yield return new WaitForSeconds(0.2f);
        ArrowKeyMovement.playerControl = true;
    }

    IEnumerator FlashSprite()
    {
        float stopTime = Time.time + iFrameDuration;
        while (Time.time < stopTime)
        {
            yield return new WaitForSeconds(0.05f);
            sr.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sr.enabled = true;
        }
        iFrame = false;
    }
}
