using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 newPosition;
    private float prevMousePosition;
    private void FixedUpdate()
    {
        newPosition = transform.position;
        newPosition.z += 2f * Time.fixedDeltaTime;

        if (Input.GetMouseButton(0))
        {
            float delta = (Input.mousePosition.x - prevMousePosition) / 100;
            newPosition.x = Mathf.Clamp(transform.position.x + delta, -2.18f, 2.18f);
        }

        transform.position = newPosition;
        prevMousePosition = Input.mousePosition.x;
    }
}
