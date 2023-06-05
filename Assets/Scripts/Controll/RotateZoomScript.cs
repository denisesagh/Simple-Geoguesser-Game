using UnityEngine;

public class RotateZoomScript : MonoBehaviour
{
    private float rotationSpeed = 1f;
    private float zoomSpeed = 5f;
    private bool isRotating = false;
    private Vector3 initialMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            initialMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseOffset = currentMousePosition - initialMousePosition;

            float rotationX = -mouseOffset.y * rotationSpeed;
            float rotationY = mouseOffset.x * rotationSpeed;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            initialMousePosition = currentMousePosition;
        }


    }
}
