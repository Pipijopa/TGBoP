using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostaBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private PlayerStatus player1Status, player2Status;
    private Animator animatorDd;
    private int timeBuster = 10;
    [SerializeField] Effects ef;

    void Start()
    {
        ef = GameObject.Find("HUD").GetComponent<Effects>();
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1Status = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2Status = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        animatorDd = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnHeroes.GetNamePl1() || collision.name == spawnHeroes.GetNamePl2() && !collision.isTrigger)
        {
            animatorDd.SetBool("pincing", true);

            if (collision.name == spawnHeroes.GetNamePl1())
            {
                player1Status.SetSpeedBust—oefficient(2, timeBuster);
                ef.bankiP1(3);
            }
            else
            {
                player2Status.SetSpeedBust—oefficient(2, timeBuster);
                ef.bankiP2(3);
            }
        }
    }

    public void OnDestr()
    {
        Destroy(gameObject);
    }
}
