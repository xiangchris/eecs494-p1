using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip rupeeCollectionSFX;
    Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        if (inventory == null)
            Debug.LogWarning("WARNING: Gameobject with collider has no inventory to store things in!");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;

        if (collidedWith.tag == "rupee")
        {
            if (inventory != null)
                inventory.AddRupees(1);
            Destroy(collidedWith);
            AudioSource.PlayClipAtPoint(rupeeCollectionSFX, Camera.main.transform.position);
        }
    }
}
