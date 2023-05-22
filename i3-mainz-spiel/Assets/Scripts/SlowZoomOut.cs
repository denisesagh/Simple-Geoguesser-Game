using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoomOut : MonoBehaviour
{
    
    bool _reachedTargetZPosition;
    void Update(){
        
        double currentZPosition = transform.position.z;

        if (currentZPosition == -25)
        {
            _reachedTargetZPosition = true;
        }

        if (currentZPosition == -20)
        {
            _reachedTargetZPosition = false;
        }

        if (_reachedTargetZPosition == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -25), 0.01f);
        }

        if (_reachedTargetZPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -20), 0.01f);
        }
        
        
        
        
    }
}
