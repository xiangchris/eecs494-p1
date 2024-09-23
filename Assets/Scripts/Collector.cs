using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip rupeeCollectionSFX;
    Inventory inventory;
    HasHealth health;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        health = GetComponent<HasHealth>();
        if (inventory == null)
            Debug.LogWarning("WARNING: Gameobject with collider has no inventory to store things in!");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;

        if (collidedWith.tag == "rupee")
        {
            if (inventory != null)
                inventory.AddItem(Inventory.Item.Rupees, 1);
            Destroy(collidedWith);
            AudioSource.PlayClipAtPoint(rupeeCollectionSFX, Camera.main.transform.position);
        }
        if (collidedWith.tag == "heart")
        {
            if (health != null && health.GetHealth() < Utility.MAX_HEALTH)
                health.AddHealth(1);
            Destroy(collidedWith);
            // TODO: fix this sound
            AudioSource.PlayClipAtPoint(rupeeCollectionSFX, Camera.main.transform.position);
        }
    }
}
