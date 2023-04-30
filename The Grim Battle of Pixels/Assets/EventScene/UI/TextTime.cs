using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{
    [SerializeField] private Event ev;
    private string text1;
    // Start is called before the first frame update
    void Start()
    {
        text1 = "врн-рн опнхгнидер вепег ";
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = text1 + '"' + ev.GetTimer().ToString() + '"';
    }
}
