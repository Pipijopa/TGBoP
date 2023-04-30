using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smert : MonoBehaviour
{

    private SpawnHeroes spawnHeroes;
    private GameObject pl1, pl2;
    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        pl1 = GameObject.Find(spawnHeroes.GetNamePl1());
        pl2 = GameObject.Find(spawnHeroes.GetNamePl2());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == pl1.name)
            pl1.GetComponent<PlayerStatus>().TakeDamage(200);

        if (collision.name == pl2.name)
            pl2.GetComponent<PlayerStatus>().TakeDamage(200);
    }
}
