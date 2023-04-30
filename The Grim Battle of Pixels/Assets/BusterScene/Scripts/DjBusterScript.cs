using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private PlayerStatus player1Battle, player2Battle;
    private Animator animatorDj;
    private int timeBuster = 10;
    [SerializeField] Effects ef;

    void Start()
    {
        ef = GameObject.Find("HUD").GetComponent<Effects>();
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1Battle = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2Battle = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        animatorDj = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnHeroes.GetNamePl1() || collision.name == spawnHeroes.GetNamePl2() && !collision.isTrigger)
        {
            animatorDj.SetBool("pincing", true);

            if (collision.name == spawnHeroes.GetNamePl1())
            {
                player1Battle.SetJump—oefficient(1.5f, timeBuster);
                ef.bankiP1(2);
            }
            else
            {
                player2Battle.SetJump—oefficient(1.5f, timeBuster);
                ef.bankiP2(2);
            }
        }
    }

    public void OnDestr()
    {
        Destroy(gameObject);
    }
}
