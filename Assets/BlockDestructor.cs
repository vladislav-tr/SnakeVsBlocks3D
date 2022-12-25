using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDestructor : MonoBehaviour
{
    private DurabilityIndicator selfDurabilityIndicator;
    private DurabilityIndicator snakeDurabilityIndicator;
    private SnakeLength snakeLength;
    private PlayerController playerController;
    private float timer = 0;
    private void Start()
    {
        selfDurabilityIndicator = GetComponent<DurabilityIndicator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        snakeDurabilityIndicator = other.GetComponent<DurabilityIndicator>();
        snakeLength = other.GetComponent<SnakeLength>();
        playerController = other.GetComponent<PlayerController>();
    }
    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if (timer > 0.05f)
        {
            if (transform.position.z - other.transform.position.z < 0.75) return;

            selfDurabilityIndicator.durability -= 1;
            snakeDurabilityIndicator.durability -= 1;

            if (selfDurabilityIndicator.durability == 0)
            {
                Destroy(gameObject);
                return;
            }
            if (snakeDurabilityIndicator.durability == 0)
            {
                playerController.OnDie();
                return;
            }

            snakeLength.Grow();
            timer = 0;
        }
    }
}
