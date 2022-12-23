using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDestructor : MonoBehaviour
{
    private DurabilityIndicator selfDurabilityIndicator;
    private DurabilityIndicator snakeDurabilityIndicator;
    private SnakeLength snakeLength;
    private float timer = 0;
    private void Start()
    {
        selfDurabilityIndicator = GetComponent<DurabilityIndicator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        snakeDurabilityIndicator = other.GetComponent<DurabilityIndicator>();
        snakeLength = other.GetComponent<SnakeLength>();
    }
    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if (timer > 0.05f)
        {
            if (transform.position.z - other.transform.position.z < 0.75) return;
            selfDurabilityIndicator.durability -= 1;
            snakeDurabilityIndicator.durability -= 1;
            snakeLength.Grow();
            timer = 0;
        }
    }
}
