using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDisplayer : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent != null)
            textComponent.text = EquippedWeapon.GetEquipped().ToString();
    }
}
