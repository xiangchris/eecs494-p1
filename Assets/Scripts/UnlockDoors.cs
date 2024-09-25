using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoors : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "lock" && inventory.GetItem(Inventory.Item.Keys) > 0)
        {
            inventory.AddItem(Inventory.Item.Keys, -1);
            other.tag = "door";

            var lockedDoor = other.GetComponent<LockedDoor>();
            lockedDoor.UnlockDoor();
        }
    }
}
