using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public SwordProjectile sp;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //TODO: Check if health is full
            sp.StartMovement(transform.position);
            StartCoroutine(FreezePlayer());
        }
    }

    IEnumerator FreezePlayer()
    {
        rb.velocity = Vector3.zero;
        ArrowKeyMovement.player_control = false;
        yield return new WaitForSeconds(0.17f);
        ArrowKeyMovement.player_control = true;
    }
}
