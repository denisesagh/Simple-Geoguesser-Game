using CesiumForUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOnMap : MonoBehaviour
{
    public void SetObj(GameObject cubePrefab, Vector3 coordLatLonHeight)
    {
        // spawn at init pos
        GameObject thisObj = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);

        // attach to parent to get geo functionality
        GameObject geoParent = GameObject.FindGameObjectsWithTag("geoBehaviourParent")[0];
        thisObj.transform.parent = geoParent.transform;

        // get unity-coord from geo-coord
        CesiumGlobeAnchor geoScript = thisObj.AddComponent<CesiumGlobeAnchor>();
        geoScript.latitude = coordLatLonHeight.x;
        geoScript.longitude = coordLatLonHeight.y;
        geoScript.height = coordLatLonHeight.z;
    }


    //// ------------- example (not needed) -------------

    //public GameObject objPrefab;
    //public Vector3 coordLatLonHeight;

    //void Start()
    //{
    //    SetObj(objPrefab, coordLatLonHeight);
    //    //SetObj(GameObject.CreatePrimitive(PrimitiveType.Sphere), coordLatLonHeight);
    //}

}
