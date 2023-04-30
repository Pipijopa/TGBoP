using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
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
        fillP1 = GameObject.Find("HPFillP1").GetComponent<Image>();
        fillP2 = GameObject.Find("HPFillP2").GetComponent<Image>();
        player1 = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        player2 = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        SetHP(player1.getCurrentHeath(), fillP1, player1);
        SetHP(player2.getCurrentHeath(), fillP2, player2);
    }

    private void Update()
    {
        SetHP(player1.getCurrentHeath(), fillP1, player1);
        SetHP(player2.getCurrentHeath(), fillP2, player2);
    }

    public void SetHP(float hp, Image fill, PlayerStatus player)
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, hp / player.getMaxHeath(), Time.deltaTime * speedTransformation);
    }
}
