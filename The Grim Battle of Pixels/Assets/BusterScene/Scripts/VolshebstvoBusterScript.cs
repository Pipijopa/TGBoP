using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolshebstvoBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private AnimationAbstract player1Animation, player2Animation;
    private PlayerStatus player1St, player2St;
    private Animator animatorVolshebstvo;
    private int timeBuster = 10;
    [SerializeField] Effects ef;

    void Start()
    {
        ef = GameObject.Find("HUD").GetComponent<Effects>();
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1Animation = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<AnimationAbstract>();
        player2Animation = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<AnimationAbstract>();
        player1St = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2St = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        animatorVolshebstvo = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnHeroes.GetNamePl1() || collision.name == spawnHeroes.GetNamePl2() && !collision.isTrigger)
        {
            animatorVolshebstvo.SetBool("pincing", true);

            if (collision.name == spawnHeroes.GetNamePl1())
            {
                player1Animation.SetTimeBusterCoefficient(2, timeBuster);
                player1St.SetManaSetCoefficient(2, timeBuster);
                ef.bankiP1(0);
            }
            else
            {
                player2Animation.SetTimeBusterCoefficient(2, timeBuster);
                player2St.SetManaSetCoefficient(2, timeBuster);
                ef.bankiP2(0);
            }
        }
    }

    public void OnDestr()
    {
        Destroy(gameObject);
    }
}
