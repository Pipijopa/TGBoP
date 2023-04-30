using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSakyla : BattleAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private PlayerStatus plStEnemy;
    private PlayerStatus plSt;
    private GameObject Enemy;
    private bool check_kick;                            // проигрывается ли анимация удара
    private bool botKick, topKick;                      // можно ли бить
    private bool bot_kick = false, top_kick = false;    // произошел удар или нет
    private int bot_damage = 15, top_damage = 12;
    private int damageCoefficient = 1;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plSt = GetComponent<PlayerStatus>();
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
        if (check_kick)                     // проверяет не использует ли удар
            topKick = botKick = true;
        check_kick = !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                            && !animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick");
    }

    void FixedUpdate()
    {
        if (botKick)
        {
            bot_kick = true;
            botKick = false;
        }
        else if (topKick)
        {
            top_kick = true;
            topKick = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bot_kick && collision != null && collision.name == Enemy.name                   
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick") && !collision.isTrigger)       // если попал нижним
        {
            plSt.setCurrentMana(5);
            plStEnemy.TakeDamage(bot_damage * damageCoefficient);
            bot_kick = false;
        }
        if (top_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)          // если попал верхним
        {
            plSt.setCurrentMana(5);
            plStEnemy.TakeDamage(top_damage * damageCoefficient);
            top_kick = false;
        }
    }

    override
    public void SetDamageCoefficient(int newDamage, int time)
    {
        damageCoefficient = newDamage;
        Invoke("returnDamageCoefficient", time);
    }

    override
    public void returnDamageCoefficient()
    {
        damageCoefficient = 1;
    }
}
