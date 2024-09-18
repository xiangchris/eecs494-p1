using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> InventoryItems = new Dictionary<Item, int>();
    public enum Item
    {
        Rupees,
        Bombs,
        Keys,
    }
    void Start()
    {
        InventoryItems.Clear();
        foreach (Item i in Enum.GetValues(typeof(Item)))
        {
            InventoryItems[i] = 0;
        }
    }

    public void AddItem(Item item, int amount)
    {
        InventoryItems[item] += amount;
    }

    public int GetItem(Item item)
    {
        return InventoryItems[item];
    }
}
