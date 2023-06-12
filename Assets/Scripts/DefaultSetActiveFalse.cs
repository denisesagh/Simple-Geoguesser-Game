using Unity.VisualScripting;
using UnityEngine;



public class DefaultSetActiveFalse : MonoBehaviour 
{
    public GameObject obj;

    private void Start()
    {
        obj.SetActive(false);
    }

}
