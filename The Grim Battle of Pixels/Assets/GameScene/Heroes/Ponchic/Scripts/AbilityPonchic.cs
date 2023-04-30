using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPonchic : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private PlayerStatus plStEnemy;
    private bool isAbilityReady = false;
    private bool isAbilityRunning = true;
    private bool isUltaRunning = true;
    private bool isEnemyPoisoned = false;


    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()).gameObject;
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1()).gameObject;
        }

        plStEnemy = Enemy.GetComponent<PlayerStatus>();
    }


    void Update()
    {
        if (isEnemyPoisoned)
        {
            Enemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
        }

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
        if (collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ulta_walking") && !collision.isTrigger && isUltaRunning)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            Enemy.GetComponent<PlayerStatus>().setForce(15 * new Vector2(Enemy.transform.position.x - transform.position.x,
                Enemy.transform.position.y - transform.position.y));
            plStEnemy.TakeDamage(7);
            isUltaRunning = false;
            Invoke("setIsUltaRunning", 0.2f);
        }

        if (isAbilityReady && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(15);
            isEnemyPoisoned = true;
            Enemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
            Invoke("abilityDamage", 7);
            isAbilityReady = false;
        }
    }

    public void abilityDamage()                     // второй тик способности
    {
        plStEnemy.TakeDamage(20);
        isEnemyPoisoned = false;
        Enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void setIsUltaRunning()
    {
        isUltaRunning = true;
    }

    public void newSpeed()              // присвоить скорость в ульте
    {
        plSt.setSpeed(1000);
    }

    public void newSpeed1()             // присвоить скорость после ульты
    {
        plSt.setSpeed(500);
    }
}
