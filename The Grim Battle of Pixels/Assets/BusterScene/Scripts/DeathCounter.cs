using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter: MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private PlayerStatus player1St, player2St;
    private int deathCountPlayer1 = 0, deathCountPlayer2 = 0;
    private int maxDeath = 3;

    public int getDCP1() { return deathCountPlayer1; }

    public int getDCP2() { return deathCountPlayer2; }

    public int getMD() { return maxDeath; }

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1St = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2St = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
    }

    public void DeathPlayer(bool isPlayer1)
    {
        if (isPlayer1)
            deathCountPlayer1++;
        else
            deathCountPlayer2++;
    }

}
