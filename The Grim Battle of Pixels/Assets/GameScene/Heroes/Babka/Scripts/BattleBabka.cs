using UnityEngine;

public class BattleBabka : BattleAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private PlayerStatus plStEnemy;
    private PlayerStatus myPlSt;
    private GameObject Enemy;
    private bool check_kick = false;
    private bool botKick, topKick;
    private bool bot_kick = false, top_kick = false;
    private int bot_damage = 14, top_damage = 12;
    private int damageCoefficient = 1;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        animator = GetComponent<Animator>();
        myPlSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2());
            plStEnemy = Enemy.GetComponent<PlayerStatus>();
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
            plStEnemy = Enemy.GetComponent<PlayerStatus>();
        }
    }



    void Update()
    {
        if (check_kick)
            topKick = botKick =true;
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
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick") && !collision.isTrigger)
        {
            myPlSt.setCurrentMana(5);
            plStEnemy.TakeDamage(bot_damage * damageCoefficient);
            bot_kick = false;
        }
        if (top_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)
        {
            myPlSt.setCurrentMana(5);
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

    public void SetKick()
    {
        bot_kick = true;
        top_kick = true;
    }
}





