using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(0,0,2f);
    }
    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
