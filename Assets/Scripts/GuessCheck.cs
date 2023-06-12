using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var location = PlayerPrefs.GetString("location");
        print(location);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
