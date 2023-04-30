using System.Collections;
using UnityEngine;
using System;

public class Hilka : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animatorHeal;
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    System.Random rnd = new System.Random();
    private int timeSpawn = 15;
    private int hp = 20;
    private int nForRandom = 0;
    private string Player1;
    private string Player2;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        sprite = GetComponent<SpriteRenderer>();
        animatorHeal = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
        sprite.enabled = false;
        box.enabled = false;
        nForRandom = rnd.Next() % 6;
        switch (nForRandom)
        {
            case 0:
                transform.position = new Vector2(-2.845f, -1.688f);
                break;
            case 1:
                transform.position = new Vector2(-3.785f, -5.41f);
                break;
            case 2:
                transform.position = new Vector2(-13f, -2.31f);
                break;
            case 3:
                transform.position = new Vector2(2.845f, -1.688f);
                break;
            case 4:
                transform.position = new Vector2(3.785f, -5.41f);
                break;
            case 5:
                transform.position = new Vector2(13f, -2.31f);
                break;
        }
        Invoke("HilkaSpawn", timeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.name == Player1 || collision.name == Player2) && !collision.isTrigger)
        {
            collision.GetComponent<PlayerStatus>().Hill(hp);
            StartCoroutine("HilkaSpawnPoint");
        }
    }

    IEnumerator HilkaSpawnPoint()
    {
        box.enabled = false;
        animatorHeal.SetBool("HilkaFly", true);
        yield return new WaitForSeconds(0.6f);
        sprite.enabled = false;
        nForRandom = rnd.Next() % 6;
        switch (nForRandom)
        {
            case 0:
                transform.position = new Vector2(-2.845f, -1.688f);
                break;
            case 1:
                transform.position = new Vector2(-3.785f, -5.41f);
                break;
            case 2:
                transform.position = new Vector2(-13f, -2.31f);
                break;
            case 3:
                transform.position = new Vector2(2.845f, -1.688f);
                break;
            case 4:
                transform.position = new Vector2(3.785f, -5.41f);
                break;
            case 5:
                transform.position = new Vector2(13f, -2.31f);
                break;
        }
        Invoke("HilkaSpawn", timeSpawn);
    }

    public void HilkaSpawn()
    {
        animatorHeal.SetBool("HilkaFly", false);
        sprite.enabled = true;
        box.enabled = true;
    }
}