using System;
using System.Collections;
using System.Collections.Generic;
using CesiumForUnity;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GeoGuessGameplayScript : MonoBehaviour
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

   private String rightLocation;
   private void Start()
   {
      rightLocation = PlayerPrefs.GetString("location");

      switch (rightLocation)
      {
         case "Syrien":
         {
            TürkeiPointer.SetActive(false);
            ZimbabwePointer.SetActive(false);
            KrimPointer.SetActive(false);
            ItalienPointer.SetActive(false);
            Renderer[] renderers = SyrienPointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            FrancePointer.SetActive(false);
            return;
         }
         case "Zimbabwe":
         {
            TürkeiPointer.SetActive(false);
            Renderer[] renderers = ZimbabwePointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            KrimPointer.SetActive(false);
            ItalienPointer.SetActive(false);
            SyrienPointer.SetActive(false);
            FrancePointer.SetActive(false);
            return;
         }
         case "Türkei":
         {
            Renderer[] renderers = TürkeiPointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            ZimbabwePointer.SetActive(false);
            KrimPointer.SetActive(false);
            ItalienPointer.SetActive(false);
            SyrienPointer.SetActive(false);
            FrancePointer.SetActive(false);
            return;
         }
         case "France":
         {
            TürkeiPointer.SetActive(false);
            ZimbabwePointer.SetActive(false);
            KrimPointer.SetActive(false);
            ItalienPointer.SetActive(false);
            SyrienPointer.SetActive(false);
            Renderer[] renderers = FrancePointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            return;
         }
         case "Krim":
         {
            TürkeiPointer.SetActive(false);
            ZimbabwePointer.SetActive(false);
            Renderer[] renderers = KrimPointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            ItalienPointer.SetActive(false);
            SyrienPointer.SetActive(false);
            FrancePointer.SetActive(false);
            return;
         }
         case "Italien":
         {
            TürkeiPointer.SetActive(false);
            ZimbabwePointer.SetActive(false);
            KrimPointer.SetActive(false);
            Renderer[] renderers = ItalienPointer.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
               renderer.enabled = false;
            }
            SyrienPointer.SetActive(false);
            FrancePointer.SetActive(false);
            return;
         }
      }

   }
   
}