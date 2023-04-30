using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zelen : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animatorGrass;
    private string Player1;
    private string Player2;
    private int count;

    public void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animatorGrass = GetComponent<Animator>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 && !collision.isTrigger)
        {
            count++;
            if (count > 0)
                animatorGrass.SetBool("zelen", true);
            else
                animatorGrass.SetBool("zelen", false);
        }
        if (collision.name == Player2 && !collision.isTrigger)
        {
            count++;
            if (count > 0)
                animatorGrass.SetBool("zelen", true);
            else
                animatorGrass.SetBool("zelen", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == Player1 && !collision.isTrigger)
        {
            count--;
            if (count > 0)
                animatorGrass.SetBool("zelen", true);
            else
                animatorGrass.SetBool("zelen", false);
        }
        if (collision.name == Player2 && !collision.isTrigger)
        {
            count--;
            if (count > 0)
                animatorGrass.SetBool("zelen", true);
            else
                animatorGrass.SetBool("zelen", false);
        }
    }
}
