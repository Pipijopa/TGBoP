using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animatorStone;
    private string Player1;
    private string Player2;

    public void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animatorStone = GetComponent<Animator>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 || collision.name == Player2)
        {
            StartCoroutine("StoneCrushed");
        }
    }


    IEnumerator StoneCrushed()
    {
        animatorStone.SetBool("stone", true);
        yield return new WaitForSeconds(0.1f);
        animatorStone.SetBool("stone", false);                    
    }
}
