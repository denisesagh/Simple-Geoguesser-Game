using System;
using System.Collections;
using System.Collections.Generic;
using CesiumForUnity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllProjectsClickHandler : MonoBehaviour
{
    private Camera mainCamera;
    private CesiumGeoreference georeference;
    public CesiumCameraController controller;
    
    private void Start()
    {
        mainCamera = Camera.main;
        georeference = FindObjectOfType<CesiumGeoreference>();
        controller = FindObjectOfType<CesiumCameraController>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 unityPosition = hit.point;
                print(unityPosition);

                string gameObjectName = hit.collider.gameObject.name;
                print(gameObjectName);
                
                
             
                
                switch (gameObjectName)
                {
                    
                    case "SyrienPointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "Syrien");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    case "ZimbabwePointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "Zimbabwe");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    case "TürkeiPointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "Türkei");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    case "FrancePointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "France");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    case "KrimPointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "Krim");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    case "ItalienPointerAll":
                    {
                        PlayerPrefs.SetString("infoPointer", "Italien");
                        SceneManager.LoadScene(sceneName: "PlaceInformation");
                        return;
                    }
                    return;
                }
                

            }
        }
    }
}