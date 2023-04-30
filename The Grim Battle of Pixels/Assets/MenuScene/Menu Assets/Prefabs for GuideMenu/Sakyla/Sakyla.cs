using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakyla : MonoBehaviour
{
    [SerializeField] GameObject vodka;
    // Start is called before the first frame update
   void tp_forward()
    {
        transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
    }
    void tp_back()
    {
        transform.position = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
    }
    void zxc()
    {
        Instantiate(vodka, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
