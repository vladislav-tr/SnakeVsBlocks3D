using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeLength : MonoBehaviour
{
    public GameObject snakePartPrefab;
    private DurabilityIndicator durabilityIndicator;
    private int previousLength;
    private Transform lastPart;
    private void Start()
    {
        durabilityIndicator = GetComponent<DurabilityIndicator>();
        previousLength = durabilityIndicator.durability/5;
    }
    public void Grow()
    {
        int growth = durabilityIndicator.durability/5 - previousLength;
        if (growth == 0) return;

        lastPart = transform.parent.GetChild(transform.parent.childCount - 1);

        if (growth > 0)
        {
            Vector3 position = new Vector3(lastPart.position.x, lastPart.position.y, lastPart.position.z - 0.6f);
            Instantiate(snakePartPrefab, position, Quaternion.identity, gameObject.transform.parent);
        }
        if (growth < 0)
        {
            if (lastPart.name == "SnakeHead") return;
            Destroy(lastPart.gameObject);
        }

        previousLength = durabilityIndicator.durability / 5;
    }
}
