using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTehnik : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    [SerializeField] GameObject shield;             // объект щита
    private Animator playerAnimator;                // аниматор персонажа
    private Animator shieldAnimator;                // аниматор щита
    private GameObject Enemy;
    private PlayerStatus enemyStatus;
    private PlayerStatus playerStatus;
    private bool isAbilityRunning = false;          // если выполняется анимация способности
    private bool isAbilityComplited = true;         // если анимация способности закончена


    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        playerAnimator = GetComponent<Animator>();
        shieldAnimator = shield.GetComponent<Animator>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()); 
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        enemyStatus = Enemy.GetComponent<PlayerStatus>();
        playerStatus = GetComponent<PlayerStatus>();
    }


    void Update()
    {

        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ability"))
            isAbilityComplited = true;
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ability") && isAbilityComplited)
        {
            isAbilityRunning = true;
            isAbilityComplited = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAbilityRunning && collision != null && collision.name == Enemy.name               
                    && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)             // если попали способностью
        {
            shield.SetActive(true);
            playerStatus.SetCurrentArmor(30);
            enemyStatus.TakeDamage(35);
            isAbilityRunning = false;
            StartCoroutine("isArmor");
        }
    }

    IEnumerator isArmor()                                 // корутина, которая проверяет, есть ли у персонажа броня от щита
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (playerStatus.GetCurrentArmor() == 0)
            {
                shieldAnimator.SetBool("shit", true);
                break;
            }
        }
    }
}
