using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onsel : MonoBehaviour, ISelectHandler
{
    private MenuScript ms;

    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
    }

}
