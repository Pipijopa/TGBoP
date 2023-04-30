using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarPlayer : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Image fillP1;
    private Image fillP2;
    private PlayerStatus player1;
    private PlayerStatus player2;
    private float speedTransformation = 10f;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        fillP1 = GameObject.Find("MPFillP1").GetComponent<Image>();
        fillP2 = GameObject.Find("MPFillP2").GetComponent<Image>();
        player1 = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2 = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        SetMP(player1.getCurrentMana(), fillP1, player1);
        SetMP(player2.getCurrentMana(), fillP2, player2);
    }

    private void Update()
    {
        SetMP(player1.getCurrentMana(), fillP1, player1);
        SetMP(player2.getCurrentMana(), fillP2, player2);
    }

    public void SetMP(float mp, Image fill, PlayerStatus player)
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, mp / player.getMaxMana(), Time.deltaTime * speedTransformation);
    }
}
