using System;
using System.Collections;
using System.Collections.Generic;
using CesiumForUnity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class AllProjectsClickHandler : MonoBehaviour
{
    private Camera mainCamera;
    private CesiumGeoreference georeference;
    [SerializeField] 
    public TextMeshProUGUI locationPlaceholder;
    [SerializeField] 
    public TextMeshProUGUI gefördertPlaceholder;
    [SerializeField] 
    public TextMeshProUGUI partnerPlaceholder;
    [SerializeField] 
    public TextMeshProUGUI linkPlaceholder;
    [SerializeField] 
    private TextMeshProUGUI titlePlaceholder;
    public GameObject pointerInfoUI;

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
                    
                    case "SyrienPointer":
                    {
                        titlePlaceholder.text = "Mediale Verdeutlichung der Ergebnisse und Tätigkeiten im Kontext der archäologischen Ausgrabung zu Qatna";
                        locationPlaceholder.text = "Qatna (Syrien)";
                        gefördertPlaceholder.text = "DFG";
                        partnerPlaceholder.text = "Universität Tübingen";
                        linkPlaceholder.text = "i3mainz";
                        pointerInfoUI.SetActive(true);
                        return;
                    }
                    case "ZimbabwePointer":
                    {
                        titlePlaceholder.text = "The Past in the Present";
                        locationPlaceholder.text = "Zimbabwe (Afrika)";
                        gefördertPlaceholder.text = "Volkswagen Stiftung";
                        partnerPlaceholder.text = "University of Zimbabw";
                        linkPlaceholder.text = "i3mainz";
                        pointerInfoUI.SetActive(true);
                        return;
                    }
                    case "TürkeiPointer":
                    {
                        return;
                    }
                    case "FrancePointer":
                    {
                        return;
                    }
                    case "KrimPointer":
                    {
                        return;
                    }
                    case "ItalienPointer":
                    {
                        return;
                    }
                    return;
                }

            }
        }
    }
}