using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskLeft : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Transform transformObject;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;




    // Start is called before the first frame update
    void Start()
    {
        transformObject = GetComponent<Transform>();
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        plSt1 = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        StartCoroutine("DisksSpin");
    }

    IEnumerator DisksSpin()
    {
        for (int i = 0; i < 110; i++)
        {
            transformObject.position = new Vector3(transformObject.position.x + 0.1f, transformObject.position.y, transformObject.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 110; i++)
        {
            transformObject.position = new Vector3(transformObject.position.x - 0.1f, transformObject.position.y, transformObject.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl1())
            plSt1.TakeDamage(100);
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl2())
            plSt2.TakeDamage(100);
    }
}
