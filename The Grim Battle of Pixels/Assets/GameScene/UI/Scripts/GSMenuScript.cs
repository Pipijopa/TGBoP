using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GSMenuScript : MonoBehaviour
{
    private GameObject lastSelectedButton;

    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedButton);
        }
    }

    public void setLSB(GameObject LSB)
    {
        lastSelectedButton = LSB;
    }
}
