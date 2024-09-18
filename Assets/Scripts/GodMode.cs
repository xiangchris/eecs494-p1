using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public static bool godMode = false;
    public HasHealth health;
    public Inventory inv;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            godMode = !godMode;
            inv.AddItem(Inventory.Item.Rupees, 9999);
            inv.AddItem(Inventory.Item.Bombs, 9999);
            inv.AddItem(Inventory.Item.Keys, 9999);
            Debug.Log("God Mode = " + godMode.ToString());
        }

        if (godMode)
        {
            health.SetHealth(Utility.MAX_HEALTH);
        }
    }
}
