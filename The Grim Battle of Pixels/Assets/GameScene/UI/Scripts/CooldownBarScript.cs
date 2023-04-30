using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CooldownBarScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private GameObject playerCommon1;
    private GameObject playerCommon2;
    private AnimationAbstract player1;
    private AnimationAbstract player2;
    private GameObject cooldownUI1;
    private GameObject cooldownUI2;


    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        playerCommon1 = GameObject.Find(spawnHeroes.GetNamePl1());
        playerCommon2 = GameObject.Find(spawnHeroes.GetNamePl2());

        cooldownUI1 = GameObject.Find("CDP1");
        cooldownUI2 = GameObject.Find("CDP2");

        player1 = playerCommon1.GetComponent<AnimationAbstract>();
        player2 = playerCommon2.GetComponent<AnimationAbstract>();
    }

    private void Update()
    {
        if (player1.getFlagAbility())
        {
            setIcon(cooldownUI1, 0);
        }
        else
        {
            setIcon(cooldownUI1, (int)(10 - player1.getTime()));
        }

        if (player2.getFlagAbility())
        {
            setIcon(cooldownUI2, 0);
        }
        else
        {
            setIcon(cooldownUI2, (int)(10 - player2.getTime()));
        }
    }

    private void setIcon(GameObject cdUI, int a)
    {
        if ((a > -1) && (a < 10))
        {
            for (int i = 0; i < 10; ++i)
                cdUI.transform.GetChild(i).gameObject.SetActive(i == a);
        }

    }
}
