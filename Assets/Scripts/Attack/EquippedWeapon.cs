using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    public enum Weapon
    {
        Bow,
        Bomb,
        Boomerang
    }

    public static Weapon equipped;

    void Start()
    {
        equipped = Weapon.Bow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            equipped += 1;
            if ((int)equipped > 2)
            {
                equipped = 0;
            }
        }
    }

    public static Weapon GetEquipped() { return equipped; }
}
