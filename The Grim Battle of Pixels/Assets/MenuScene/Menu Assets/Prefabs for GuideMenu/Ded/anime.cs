using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    private Animator ani;
    private GameObject cepi;
    void Start()
    {
        cepi = transform.GetChild(0).gameObject;
        ani = GetComponent<Animator>();
    }


    void cepiOFF() 
    {
        cepi.SetActive(false);
    }
    void cepiON()
    {
        cepi.SetActive(true);
    }
    void aniStart()
    {
        ani.SetBool("flag", true);
    }
}
