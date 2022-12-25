using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private void FixedUpdate()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, Player.position.z - 5.85f);
        transform.position = position;
    }
}
