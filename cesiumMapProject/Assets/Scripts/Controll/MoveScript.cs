using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 currentPosition = GetMouseWorldPosition() + offset;
            transform.position = currentPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = screenPoint.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}