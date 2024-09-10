using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupeeCount = 0;

    public void AddRupees(int numRupees)
    {
        rupeeCount += numRupees;
    }

    public int getRupees()
    {
        return rupeeCount;
    }
}
