using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDed : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plStEnemy;
    private bool isAbilityReady = false;
    private bool isAbilityRunning = true;
    private bool oncePerTick = true;             // ограничивает урон за один прыжок


    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        plStEnemy = Enemy.GetComponent<PlayerStatus>();
    }


    void Update()
    {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ability"))
            isAbilityRunning = true;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && isAbilityRunning)
        {
            isAbilityReady = true;
            isAbilityRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAbilityReady && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability1") && !collision.isTrigger && oncePerTick)
        {
            plStEnemy.TakeDamage(14);
            oncePerTick = false;
        }
    }

    private void SetOncePerTick() {
        oncePerTick = true;
    }
}
