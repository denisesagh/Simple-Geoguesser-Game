using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using System;
using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        // Stelle sicher, dass ein EventSystem im Szenen-Hierarchie vorhanden ist
        if (EventSystem.current == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }

        // Füge ein CanvasRenderer- und ein GraphicRaycaster-Komponente hinzu, falls sie noch nicht existieren
        Canvas canvas = GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<GraphicRaycaster>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Objekt angeklickt: " + gameObject.name);
    }
}
