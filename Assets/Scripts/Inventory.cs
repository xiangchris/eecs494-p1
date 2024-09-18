using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupeeCount = 0;
    int bombCount = 0;

    public void AddRupees(int x)
    {
        rupeeCount += x;
    }

    public void AddBomb(int x)
    {
        bombCount += x;
    }

    public void SetRupees(int x)
    {
        rupeeCount = x;
    }

    public void SetBomb(int x)
    {
        bombCount = x;
    }

    public int getRupees()
    {
        return rupeeCount;
    }

    public int getBomb()
    {
        return bombCount;
    }
}
