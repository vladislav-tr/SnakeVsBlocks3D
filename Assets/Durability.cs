using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Durability : MonoBehaviour
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
        foreach (TextMeshPro number in Numbers)
        {
            number.text = durability.ToString();
        }
    }
}
