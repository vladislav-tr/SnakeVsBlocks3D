using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DurabilityIndicator : MonoBehaviour
{
    public int durability;
    private List<TextMeshPro> Numbers = new List<TextMeshPro>();
    private void Awake()
    {
        TextMeshPro newNumber;
        int numbersCount = transform.childCount;
        for (int i = 0; i < numbersCount; ++i)
        {
            newNumber = transform.GetChild(i).GetComponent<TextMeshPro>();
            if (newNumber != null) Numbers.Add(newNumber);
        }
    }
    private void Update()
    {
        foreach (TextMeshPro number in Numbers)
        {
            number.text = durability.ToString();
        }
    }
}
