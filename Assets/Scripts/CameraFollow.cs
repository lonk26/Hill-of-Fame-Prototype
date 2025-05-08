using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // position to follow
    public Transform lookAtTarget;   // where the camera looks
    public Vector3 offset = new Vector3(0, 2, -6);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAtTarget);  // more stable than the player's root
    }
}
