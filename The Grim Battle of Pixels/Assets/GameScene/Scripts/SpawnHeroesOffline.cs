using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHeroesOffline : SpawnHeroes
{
    [SerializeField] GameObject[] Heroes = new GameObject[5];
    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    [SerializeField] string[] heroesName = new string[5] { "Babka", "Ponchic", "Tehnik", "Ded", "Sakyla"};
    private int Player1;
    private int Player2;
    private string namePl1;
    private string namePl2;
    private GameObject PL1;
    private GameObject PL2;

    private Image P1I;
    private Image P2I;

    //private MenuScript msc;


    private void Awake()
    {
        /*PL1.transform.parent = GameObject.Find("Player1").transform;
         PL2.transform.parent = GameObject.Find("Player2").transform;*/
        //msc = GameObject.Find("Canvas").transform.GetComponent<MenuScript>();
        //Player1 = msc.getP1();
        //Player2 = msc.getP2();

        Player1 = MenuScript.P1;
        Player2 = MenuScript.P2;

        ///////////////////////
        PL1 = Instantiate(Heroes[Player1], new Vector3(-7, -2, 0), Quaternion.identity);
        PL2 = Instantiate(Heroes[Player2], new Vector3(7, -2, 0), Quaternion.identity);

        namePl1 = heroesName[Player1] + "(Clone)";
        namePl2 = heroesName[Player2] + "(Clone)";

        if (Player1 == Player2)
        {
            PL2.name = PL2.name + "1";
            namePl2 = namePl2 + "1";
        }

        

        P1I = GameObject.Find("IconP1").GetComponent<Image>();
        P2I = GameObject.Find("IconP2").GetComponent<Image>();

        P1I.sprite = HeroesIcons[Player1];
        P2I.sprite = HeroesIcons[Player2];
    }

    override
    public string GetNamePl1()
    {
        return namePl1;
    }

    override
    public string GetNamePl2()
    {
        return namePl2;
    }
}
