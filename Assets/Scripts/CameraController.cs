using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogError("CameraController: Target is not assigned!");
            return;
        }

        Vector3 newPosition = target.position;
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
