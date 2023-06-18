using CesiumForUnity;
using Unity.Mathematics;
using UnityEngine;

public class CesiumController : MonoBehaviour
{
    private CesiumGlobeAnchor globeAnchor;

    // rotation
    [Space(10)]
    public float rotationSpeed = 100f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    // zoom
    [Space(10)]
    public float minHeight = 100f;
    public float maxHeight = 100000f;
    public float minZoomSpeed = 100f;
    public float maxZoomSpeed = 1000f;
    private float zoomSpeedFactorPer100m = 1f;

    private float zoomFactor = 0f;
    private float zoomFactorIncrement = 0.01f;
    private float zoomAcceleration = 0.001f;
    [Space(20)]

    // pan
    public float[] heightValues = { 800f, 2253f, 22541761f };
    public float[] factorValues = { 150f, 380f, 2000f };
    private float moveSpeedFactorPer100m = 1f;
    private float originalHeight;
    private bool storedHeight = false;



    private void Start()
    {
        globeAnchor = GetComponent<CesiumGlobeAnchor>();
    }


    private void Update()
    {
        float currentHeight = (float)globeAnchor.height;
        AdjustFarClippingPlane(currentHeight);

        // Rotation
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            rotationY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f);
            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }

        // zoom
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        zoomFactor += zoomInput * zoomFactorIncrement;
        zoomFactor = Mathf.Clamp01(zoomFactor);
        float zoomSpeed = GetZoomSpeed();
        transform.Translate(0, 0, zoomSpeed, Space.Self);

        // pan
        if (Input.GetMouseButton(2))
        {
            if (!storedHeight)
            {
                originalHeight = currentHeight;
                storedHeight = true;
            }

            float moveSpeed = GetMoveSpeed();
            float moveX = -Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
            float moveZ = -Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;

            Vector3 forwardDirection = transform.forward;
            forwardDirection.y = 0;
            forwardDirection.Normalize();

            Vector3 rightDirection = transform.right;
            rightDirection.y = 0;
            rightDirection.Normalize();

            Vector3 translation = rightDirection * moveX + forwardDirection * moveZ;
            translation.y = 0;

            float heightDiff = originalHeight - currentHeight;

            transform.Translate(0, heightDiff, 0, Space.World);
            transform.Translate(translation, Space.World);
        }
        else if (Input.GetMouseButtonUp(2))
        {
            storedHeight = false;
        }
    }





    #region zoom
private void AdjustFarClippingPlane(float currentHeight)
    {
        int factor = 1000;

        if (currentHeight >= 213609.026f)
        {
            Camera.main.farClipPlane = 1000000f * factor;
        }
        else
        {
            Camera.main.farClipPlane = 1000000f;
        }
    }

    private float GetZoomSpeed()
    {
        float currentHeight = (float)globeAnchor.height;
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        float zoomSpeed = Mathf.Sign(zoomInput) * zoomAcceleration * Mathf.Abs(zoomInput);

        // Berechnung der Zoom-Geschwindigkeit basierend auf der Höhe und dem Zoomfaktor
        float zoomLevel = currentHeight / 100f;
        float zoomFactor = 1f + (zoomLevel * zoomSpeedFactorPer100m);
        zoomSpeed *= zoomFactor;

        if (zoomSpeed < 0)
        {
            zoomAcceleration += zoomFactorIncrement;
        }
        else if (zoomSpeed > 0)
        {
            zoomAcceleration -= zoomFactorIncrement;
        }

        zoomAcceleration = Mathf.Clamp(zoomAcceleration, minZoomSpeed, maxZoomSpeed);

        return zoomSpeed;
    }
    #endregion

    #region pan
    private float GetMoveSpeed()
    {
        float currentHeight = (float)globeAnchor.height;
        moveSpeedFactorPer100m = InterpolateFactorBasedOnHeight(currentHeight);
        float moveSpeed = moveSpeedFactorPer100m * (currentHeight / 100f);

        Debug.Log("Move Speed Factor: " + moveSpeedFactorPer100m);
        Debug.Log("Move Speed: " + moveSpeed);

        return moveSpeed;
    }

    private float InterpolateFactorBasedOnHeight(float height)
    {
        if (height <= heightValues[0])
        {
            return factorValues[0];
        }
        else if (height >= heightValues[2])
        {
            return factorValues[2];
        }
        else
        {
            // Perform linear interpolation between the two closest height values
            int index = 1;
            while (height > heightValues[index])
            {
                index++;
            }

            float t = (height - heightValues[index - 1]) / (heightValues[index] - heightValues[index - 1]);
            return Mathf.Lerp(factorValues[index - 1], factorValues[index], t);
        }
    }
    #endregion


    //// klick example
    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //RaycastHit hit;

    //if (Physics.Raycast(ray, out hit))
    //{
    //    double longitude = globeAnchor.longitudeLatitudeHeight.x;
    //    double latitude = globeAnchor.longitudeLatitudeHeight.y;
    //    double height = globeAnchor.longitudeLatitudeHeight.z;

    //    Debug.Log("Geographic Coordinate: " + latitude + ", " + longitude + ", " + height);
    //}
}