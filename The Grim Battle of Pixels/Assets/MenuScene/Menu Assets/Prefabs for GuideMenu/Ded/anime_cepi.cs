using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime_cepi : MonoBehaviour
{    
    Animator ded;
    private void Start()
    { 
        ded = gameObject.transform.parent.gameObject.GetComponent<Animator>();      
    }
    void cepiOFF() {
        gameObject.SetActive(false);
    }

    void aniStop()
    {
        ded.SetBool("flag",false);
    }
   
}
