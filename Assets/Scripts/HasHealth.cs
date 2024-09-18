using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = Utility.MAX_HEALTH;
    public float kbStr = 10f;

    public int getHealth()
    {
        return health;
    }

    public void damage()
    {
        health--;
        if (health < 0)
            gameObject.SetActive(false);
    }
}
