using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBabka : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plStEnemy;
    private bool isAbilityReady = false;
    private bool isAbilityRunning = true;
    private Vector2 pushDirection;
    [SerializeField] GameObject snot;


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
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            if (Enemy.transform.position.x - transform.position.x < 0)
                pushDirection = Vector2.left;
            else
                pushDirection = Vector2.right;


            Enemy.GetComponent<PlayerStatus>().setForce(9 * pushDirection);
            StartCoroutine("Force");
            plStEnemy.TakeDamage(20);
            isAbilityReady = false;
        }
    }

    IEnumerator Force()
    {
        for (int i = 0; i < 10; i++)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            Enemy.GetComponent<PlayerStatus>().setForce(9 * pushDirection);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
