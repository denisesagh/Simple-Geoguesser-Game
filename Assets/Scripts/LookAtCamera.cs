using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // Find the main camera in the scene
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Get the current position of the object
        Vector3 objectPosition = transform.position;

        // Calculate the direction to the camera
        Vector3 directionToCamera = cameraTransform.position - objectPosition;

        // Project the direction onto the XZ plane (horizontal plane)
        directionToCamera.y = 0f;

        if (directionToCamera != Vector3.zero)
        {
            // Rotate the object to face away from the camera on the vertical axis
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
            transform.rotation = targetRotation;
        }
    }
}
