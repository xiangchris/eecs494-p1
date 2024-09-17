using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupeeCount = 0;
    int health = Utility.MAX_HEALTH;

    public void AddRupees(int numRupees)
    {
        rupeeCount += numRupees;
    }

    public int getRupees()
    {
        return rupeeCount;
    }

    public int getHealth()
    {
        return health;
    }
}
