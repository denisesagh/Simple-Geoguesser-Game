using System;
using System.Collections;
using System.Collections.Generic;
using CesiumForUnity;
using Unity.Mathematics;
using UnityEngine;

public class GuessCheck : MonoBehaviour
{
    
    [SerializeField] 
    public GameObject TürkeiPointer;
    [SerializeField] 
    public GameObject ZimbabwePointer;
    [SerializeField] 
    public GameObject KrimPointer;
    [SerializeField] 
    public GameObject ItalienPointer;
    [SerializeField] 
    public GameObject SyrienPointer;
    [SerializeField] 
    public GameObject FrancePointer;

    
    private Camera mainCamera;
    private CesiumGeoreference georeference;
    private String rightLocation;
    private DialogManager dialogManager;
    private FlyToPointer flyToPointer;

    private GameObject target;

    
    
    private void Start()
    {
        mainCamera = Camera.main;
        georeference = FindObjectOfType<CesiumGeoreference>();
        rightLocation = PlayerPrefs.GetString("location");
        dialogManager = FindObjectOfType<DialogManager>();
        target = GameObject.Find(rightLocation+"Pointer");
        flyToPointer = FindObjectOfType<FlyToPointer>();

    }
    
    void SetRendererEnabledRecursive(GameObject obj, bool enabled)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = enabled;
        }

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            GameObject child = obj.transform.GetChild(i).gameObject;
            SetRendererEnabledRecursive(child, enabled);
        }
    }


    private void revealPoints()
    {
        TürkeiPointer.SetActive(true);
        ZimbabwePointer.SetActive(true);
        KrimPointer.SetActive(true);
        ItalienPointer.SetActive(true);
        SyrienPointer.SetActive(true);
        FrancePointer.SetActive(true);

        ZimbabwePointer.GetComponent<Renderer>().enabled = true;
        TürkeiPointer.GetComponent<Renderer>().enabled = true;
        KrimPointer.GetComponent<Renderer>().enabled = true;
        ItalienPointer.GetComponent<Renderer>().enabled = true;
        SyrienPointer.GetComponent<Renderer>().enabled = true;
        FrancePointer.GetComponent<Renderer>().enabled = true;
        
  

        switch (rightLocation)
      {
         case "Syrien":
         {
             
            SetRendererEnabledRecursive(SyrienPointer, true);
            return;
         }
         case "Zimbabwe":
         {
             SetRendererEnabledRecursive(ZimbabwePointer, true);
            return;
         }
         case "Türkei":
         {
             SetRendererEnabledRecursive(TürkeiPointer, true);
            return;
         }
         case "France":
         {
             SetRendererEnabledRecursive(FrancePointer, true);
            return;
         }
         case "Krim":
         {
             SetRendererEnabledRecursive(KrimPointer, true);
            return;
         }
         case "Italien":
         {
             SetRendererEnabledRecursive(ItalienPointer, true);
            return;
         }
      }




 
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
                GameObject gameObject = hit.collider.gameObject;
                string gameObjectName = gameObject.name;
                print(gameObjectName);

                if (gameObjectName == rightLocation+"Pointer")
                {
                    print("Richtig geraten es war " + rightLocation + " und du hast " + gameObjectName
                    + "geraten");
                    
                    //flyToPointer.ShowTarget();
                    revealPoints();
                    
                    dialogManager.StartDialog("Richtig geraten!");

                }
                else
                {
                    print("Falsch geraten es war " + rightLocation + " und du hast " + gameObjectName
                          + "geraten");
                    transform.position = target.transform.position;
                    revealPoints();
                    dialogManager.StartDialog("Falsch geraten! Es war " + rightLocation);
                    
                }

            }
        }
    }
}

