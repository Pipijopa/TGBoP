using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] GameObject Pivo;
    [SerializeField] GameObject Kotiki;
    [SerializeField] GameObject Diski;
    [SerializeField] GameObject Meteor;
    private int time = 15;
    private int timer = 0;
    private System.Random rnd = new System.Random();
    private int n;

    
    void Start()
    {
        StartCoroutine("randomEvent");
    }

    IEnumerator randomEvent()
    {
        while(timer < time)
        {
            yield return new WaitForSeconds(1f);
            timer++;
        }
        timer = 0;
        n = rnd.Next() % 4;
        switch (n)
        {
            case 0:
                Instantiate(Pivo);
                break;
            case 1:
                Instantiate(Diski, new Vector3(0, -1.75f, -5), transform.rotation);
                break;
            case 2:
                Instantiate(Kotiki, new Vector3(0, -2.0625f, 0), transform.rotation);
                break;
            case 3:
                Instantiate(Meteor, new Vector3(0, 0, 0), transform.rotation);
                break;
        }
        StartCoroutine("randomEvent");
    }

    public int GetTimer() { return time - timer; }
}
