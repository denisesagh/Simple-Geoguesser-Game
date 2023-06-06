using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoverText : MonoBehaviour
{
    [SerializeField] private string hoverMessage = "Hover Text";
    [SerializeField] private GameObject textFieldPrefab;

    private GameObject textFieldInstance;

    private void Start()
    {
        // Instantiate the text field prefab and disable it initially
        textFieldInstance = Instantiate(textFieldPrefab, transform.position, Quaternion.identity);
        textFieldInstance.SetActive(false);
    }

    void OnMouseOver()
    {
        // Show the text field when the mouse enters the object
        textFieldInstance.SetActive(true);
        print("AKTIV");
        textFieldInstance.GetComponentInChildren<TMPro.TextMeshPro>().text = hoverMessage;
    }

    private void OnMouseExit()
    {
        // Hide the text field when the mouse exits the object
        textFieldInstance.SetActive(false);
    }
}
