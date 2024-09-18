using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplayer : MonoBehaviour
{
    public Health health;
    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health != null && textComponent != null)
            textComponent.text = health.getHealth().ToString();
    }

}
