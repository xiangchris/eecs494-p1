using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public static bool godMode = false;
    public HasHealth health;
    public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            godMode = !godMode;
        }

        if (godMode)
        {
            inv.SetBomb(9999);
            inv.SetRupees(9999);
            health.SetHealth(Utility.MAX_HEALTH);
        }
    }
}
