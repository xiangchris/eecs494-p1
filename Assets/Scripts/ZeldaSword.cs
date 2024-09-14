using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaSword : MonoBehaviour
{
    public SwordMovement sword;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            sword.StartMovement(transform.position);
        }
    }
}
