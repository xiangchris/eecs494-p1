using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDisplayer : MonoBehaviour
{
    public Inventory inventory;
    
    public Inventory.Item item;
    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null && textComponent != null)
            textComponent.text = inventory.GetItem(item).ToString();
    }
}
