using UnityEngine;

public class SlowRotation : MonoBehaviour
{
    private bool rotateEnabled = true;
    private float rotationSpeed = 10f;

    private void Update()
    {
        if (rotateEnabled)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetMouseButtonDown(0))
        {
            rotateEnabled = !rotateEnabled;
        }
    }
}