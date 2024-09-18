using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public int health = Utility.MAX_HEALTH;
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int h)
    {
        health = h;
    }

    public void AddHealth(int h)
    {
        health += h;
    }
}
