using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockColorer : MonoBehaviour
{
    private Renderer blockRenderer;
    private DurabilityIndicator DurabilityComponent;
    private void Start()
    {
        blockRenderer = GetComponent<Renderer>();
        DurabilityComponent = GetComponent<DurabilityIndicator>();
    }
    private void FixedUpdate()
    {
        //https://stackoverflow.com/questions/5731863/mapping-a-numeric-range-onto-another

        float ratio = 135f / (99 - 1);
        float hue = 135 - ratio * (DurabilityComponent.durability - 1); //inversed from 0...135 to 135...0
        blockRenderer.material.color = Color.HSVToRGB(hue / 360, 1, 1);
    }
}
