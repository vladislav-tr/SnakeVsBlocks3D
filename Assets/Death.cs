using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnDestroy()
    {
        transform.parent.gameObject.GetComponent<PlayerController>().Die();
    }
}
