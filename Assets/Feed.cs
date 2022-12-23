using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private DurabilityIndicator durabilityIndicator;
    private void Start()
    {
        durabilityIndicator = GetComponent<DurabilityIndicator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<DurabilityIndicator>().durability += durabilityIndicator.durability;
        other.GetComponent<SnakeLength>().Grow();
        Destroy(gameObject);
    }
}
