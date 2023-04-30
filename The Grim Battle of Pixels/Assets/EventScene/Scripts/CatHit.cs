using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHit : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;


    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        plSt1 = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        Invoke("Destr", 7);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl1())
            plSt1.TakeDamage(100);
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl2())
            plSt2.TakeDamage(100);
    }

    private void Destr()
    {
        Destroy(transform.parent.gameObject);
    }
}
