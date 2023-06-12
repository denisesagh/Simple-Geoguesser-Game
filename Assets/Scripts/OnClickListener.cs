using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using System;
using TMPro;
using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine;

public class OnClickListener : MonoBehaviour
{

    public String correctLat;
    public String correctLong;
    public String correctLocation;
    public Boolean playmode;
    public GameObject pointerInfoUI;
    public String titel;
    public String location;
    public String gefördert;
    public String partner;
    public String link;

    //public GameObject titelPlaceholder;
    /*public TextMeshPro locationPlaceholder;
    public TextMeshPro gefördertPlaceholder;
    public TextMeshPro partnerPlaceholder;
    public TextMeshPro linkPlaceholder;
    */
    [SerializeField] 
    private TextMeshProUGUI titlePlaceholder;
        
    private void Update()
    {
        // Überprüfe, ob die Maustaste geklickt wurde
        
        if (Input.GetMouseButtonDown(0))
        {
            // Erzeuge einen Raycast von der Mausposition in die Szene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Überprüfe, ob der Raycast ein GameObject getroffen hat
            if (Physics.Raycast(ray, out hit))
            {
                // Überprüfe, ob das getroffene GameObject das aktuelle GameObject ist
                if (hit.collider.gameObject == gameObject)
                {
                    if(playmode)
                    // Das GameObject wurde angeklickt
                    Debug.Log("Das GameObject wurde angeklickt!");
                    var location = PlayerPrefs.GetString("location");
                    if (correctLocation == location)
                    {
                        print("richtig geraten");
                    }
                    else
                    {
                        print("Falsch es war" + location);
                    }
                }
                else
                {
                    pointerInfoUI.SetActive(true);

                    titlePlaceholder.text = titel;
                    /*locationPlaceholder.text = location;
                    gefördertPlaceholder.text = gefördert;
                    partnerPlaceholder.text = partner;
                    linkPlaceholder.text = link;
                    */
                    pointerInfoUI.SetActive(true);
                }
            }
        }
    }
}
