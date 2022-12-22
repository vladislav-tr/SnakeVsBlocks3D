using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructor : MonoBehaviour
{
    private DurabilityIndicator selfDurabilityIndicator;
    private DurabilityIndicator snakeDurabilityIndicator;
    private float timer = 0;
    private void Start()
    {
        selfDurabilityIndicator = GetComponent<DurabilityIndicator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        snakeDurabilityIndicator = other.GetComponent<DurabilityIndicator>();
    }
    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if (timer > 0.05f)
        {
            if (transform.position.z - other.transform.position.z < 0.79) return;
            selfDurabilityIndicator.durability -= 1;
            snakeDurabilityIndicator.durability -= 1;
            timer = 0;
        }
    }
}
