using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaSword : MonoBehaviour
{
    public SwordMovement swordProj;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //TODO: Check if health is full
            swordProj.StartMovement(transform.position);
            StartCoroutine(SwordAttack());
        }
    }

    IEnumerator SwordAttack()
    {
        rb.velocity = Vector3.zero;
        ArrowKeyMovement.player_control = false;
        yield return new WaitForSeconds(0.17f);
        ArrowKeyMovement.player_control = true;
    }
}