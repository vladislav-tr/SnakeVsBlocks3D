using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 newPosition;
    private float prevMousePosition;
    Ray leftRay1;
    Ray leftRay2;
    Ray rightRay1;
    Ray rightRay2;
    Ray frontRay1;
    Ray frontRay2;
    Vector3 leftBottomCorner  = new Vector3(0, 0.5f, 0);
    Vector3 leftTopCorner     = new Vector3(0, 0.5f, 0);
    Vector3 rightTopCorner    = new Vector3(0, 0.5f, 0);
    Vector3 rightBottomCorner = new Vector3(0, 0.5f, 0);
    private void Start()
    {
        leftRay1 .direction = Vector3.left;
        leftRay2 .direction = Vector3.left;
        rightRay1.direction = Vector3.right;
        rightRay2.direction = Vector3.right;
        frontRay1.direction = Vector3.forward;
        frontRay2.direction = Vector3.forward;
    }
    private void FixedUpdate()
    {
        float cx = transform.position.x;
        float cz = transform.position.z;
        (leftBottomCorner.x, leftBottomCorner.z)   = (cx - 0.25f, cz - 0.25f);
        (leftTopCorner.x, leftTopCorner.z)         = (cx - 0.25f, cz + 0.25f);
        (rightTopCorner.x, rightTopCorner.z)       = (cx + 0.25f, cz + 0.25f);
        (rightBottomCorner.x, rightBottomCorner.z) = (cx + 0.25f, cz - 0.25f);

        leftRay1.origin  = leftBottomCorner;
        leftRay2.origin  = leftTopCorner;
        frontRay2.origin = leftTopCorner;
        frontRay1.origin = rightTopCorner;
        rightRay1.origin = rightTopCorner;
        rightRay2.origin = rightBottomCorner;

        float leftBound  = getClosestPoint(leftRay1, leftRay2).x + 0.3f;
        float rightBound = getClosestPoint(rightRay1, rightRay2).x - 0.3f;
        float frontBound = getClosestPoint(frontRay1, frontRay2).z - 0.3f;

        newPosition = transform.position;

        if (Input.GetMouseButton(0))
        {
            float delta = (Input.mousePosition.x - prevMousePosition) / 100;
            newPosition.x = Mathf.Clamp(transform.position.x + delta, leftBound, rightBound);
        }
        newPosition.z = Mathf.Clamp(transform.position.z + 2f * Time.fixedDeltaTime, 0, frontBound);

        transform.position = newPosition;
        prevMousePosition = Input.mousePosition.x;
    }

    private Vector3 getClosestPoint(Ray ray1, Ray ray2)
    {
        RaycastHit hit1;
        RaycastHit hit2;
        Physics.Raycast(ray1, out hit1);
        Physics.Raycast(ray2, out hit2);
        return hit1.distance <= hit2.distance ? hit1.point : hit2.point;
    }
}
