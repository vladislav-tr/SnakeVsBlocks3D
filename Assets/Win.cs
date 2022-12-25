using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject GM;
    private void OnTriggerEnter(Collider other)
    {
        GM.GetComponent<GameController>().Win();
    }
}
