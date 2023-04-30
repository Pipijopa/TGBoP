using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreate : MonoBehaviour
{
    [SerializeField] GameObject[] meteors = new GameObject[9];

    private void Start()
    {
        StartCoroutine("Wave1");
    }


    // 0 - left 1 - right 2 - down
    IEnumerator Wave1()
    {
        Instantiate(meteors[7], transform.GetChild(0).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[6], transform.GetChild(1).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[4], transform.GetChild(4).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[8], transform.GetChild(0).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[3], transform.GetChild(3).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[8], transform.GetChild(5).position, transform.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine("Wave2");
    }

    IEnumerator Wave2()
    {
        Instantiate(meteors[4], transform.GetChild(7).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[5], transform.GetChild(1).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[0], transform.GetChild(2).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[1], transform.GetChild(2).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[3], transform.GetChild(8).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[2], transform.GetChild(9).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[4], transform.GetChild(4).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[5], transform.GetChild(6).position, transform.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine("Wave3");
    }

    IEnumerator Wave3()
    {
        Instantiate(meteors[1], transform.GetChild(4).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[0], transform.GetChild(3).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[2], transform.GetChild(1).position, transform.rotation);
        Instantiate(meteors[2], transform.GetChild(2).position, transform.rotation);
        Instantiate(meteors[2], transform.GetChild(5).position, transform.rotation);
        Instantiate(meteors[2], transform.GetChild(7).position, transform.rotation);
        Instantiate(meteors[2], transform.GetChild(9).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[1], transform.GetChild(2).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[0], transform.GetChild(1).position, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(meteors[0], transform.GetChild(3).position, transform.rotation);
        Destroy(gameObject);
    }
}
