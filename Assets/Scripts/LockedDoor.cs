using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool topDoor;

    public GameObject left;
    public GameObject right;

    public Sprite leftSprite;
    public Sprite rightSprite;

    SpriteRenderer leftSR;
    SpriteRenderer rightSR;
    
    private void Start()
    {
        if (topDoor)
        {
            leftSR = left.GetComponent<SpriteRenderer>();
            rightSR = right.GetComponent<SpriteRenderer>();
        }
        else
        {
            leftSR = GetComponent<SpriteRenderer>();
        }
    }

    public void UnlockDoor()
    {
        leftSR.sprite = leftSprite;
        if (topDoor)
        {
            rightSR.sprite = rightSprite;
        }
    }
}
