using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DurabilityIndicator : MonoBehaviour
{
    public int durability;
    private List<TextMeshPro> Numbers = new List<TextMeshPro>();
    private void Start()
    {
        int numbersCount = transform.childCount;
        for (int i = 0; i < numbersCount; ++i)
            Numbers.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<TextMeshPro>());
    }
    private void FixedUpdate()
    {
        if (durability == 0) Destroy(gameObject);
        foreach (TextMeshPro number in Numbers)
        {
            number.text = durability.ToString();
        }
    }
}
