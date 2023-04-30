using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private BattleAbstract player1Battle, player2Battle;
    private Animator animatorDd;
    private int timeBuster = 10;
    [SerializeField] Effects ef;

    void Start()
    {
        ef = GameObject.Find("HUD").GetComponent<Effects>();
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1Battle = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<BattleAbstract>();
        player2Battle = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<BattleAbstract>();
        animatorDd = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnHeroes.GetNamePl1() || collision.name == spawnHeroes.GetNamePl2() && !collision.isTrigger)
        {
            animatorDd.SetBool("pincing", true);

            if (collision.name == spawnHeroes.GetNamePl1())
            {
                player1Battle.SetDamageCoefficient(2, timeBuster);
                ef.bankiP1(1);
            }
            else
            {
                player2Battle.SetDamageCoefficient(2, timeBuster);
                ef.bankiP2(1);
            }
        }
    }

    public void OnDestr()
    {
        Destroy(gameObject);
    }
}
