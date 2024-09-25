using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    HasHealth health;

    public GameObject heart;
    public GameObject rupee;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HasHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetHealth() < 0)
            DropItem();
    }

    void DropItem()
    {
        int rand = Random.Range(0, 5);
        GameObject spawn;
        switch (rand)
        {
            case 1:
                spawn = heart;
                break;
            case 2:
                spawn = rupee;
                break;
            default:
                spawn = null;
                break;
        }
        if (spawn != null)
            Instantiate(spawn, transform.position, Quaternion.identity);
    }
}
