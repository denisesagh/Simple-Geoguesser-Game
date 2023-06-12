using UnityEngine;

using UnityEngine;

public class ObjectScaler : MonoBehaviour 
{
    public float minimumScale = 0.1f; // Minimum Scale
    
    void Update () 
    {
        Vector3 cameraPos = Camera.main.transform.position;
        float distance = Vector3.Distance(cameraPos , transform.position);
        
        float scale = Mathf.Clamp(minimumScale + (1 - minimumScale) * (1 / distance), minimumScale, 1);
        
        transform.localScale = new Vector3(scale, scale, scale);    
    }
}