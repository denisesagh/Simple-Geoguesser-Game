using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOnMap_UsingExample : MonoBehaviour
{

    SetOnMap geoScript;

    public GameObject originalObject;

    private List<(GameObject, Vector3)> exampleList;




    void Start()
    {
        GameObject newObject = Instantiate(originalObject, originalObject.transform.position, originalObject.transform.rotation);
        
        geoScript = gameObject.GetComponent<SetOnMap>();

        // obj
        GameObject exampleObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        exampleObj.transform.localScale = new Vector3(200000, 200000, 200000);
        
        exampleObj.GetComponent<Renderer>().material.color = Color.red;

        // add values
        exampleList = new List<(GameObject, Vector3)>();
        exampleList.Add((newObject, new Vector3(-17.783517f, 31.053044f, 0)));
        exampleList.Add((exampleObj, new Vector3(49.98948486726362f, 8.229072290561168f, 180f)));
        exampleList.Add((exampleObj, new Vector3(50.00136027689663f, 8.25901393590933f, 180f)));


        // set on map
        foreach ((GameObject obj, Vector3 coord) in exampleList)
        {
            geoScript.SetObj(obj, coord);
        }
    }
}