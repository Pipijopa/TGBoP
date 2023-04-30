using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animatorMana;
    private BoxCollider2D box;
    private string Player1;
    private string Player2;
    private int mana = 33;
    private float timeManaSpawn = 10f;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animatorMana = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.name == Player1 || collision.name == Player2) && !collision.isTrigger)
        {
            collision.GetComponent<PlayerStatus>().setCurrentMana(mana);
            StartCoroutine("ManaSpawn");
        }
    }

    IEnumerator ManaSpawn()
    {
        box.enabled = false;
        animatorMana.SetBool("mana", true);
        yield return new WaitForSeconds(timeManaSpawn);
        box.enabled = true;
        animatorMana.SetBool("mana", false);
    }
}
