using System;
using Unity.VisualScripting;
using UnityEngine;

public class FlyToPointer : MonoBehaviour
{
    Vector3 targetPoint;
    private GameObject target;
    private String rightLocation;

    

    public void ShowTarget()
    {

        rightLocation = PlayerPrefs.GetString("location");
        target = GameObject.Find(rightLocation+"Pointer");

        if (target)
        {
            transform.position = target.transform.position + new Vector3(999f, 999f, -9999f);;
        }
        else
        {
            print("kein target");
        }
        

    }
    


}