using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyVodavrot : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private float speed = 1000f;                        // �������� ����������
    private Rigidbody2D _body;
    private GameObject enemy;
    private GameObject player;
    private PlayerStatus plStEnemy;
    private Animator whirlpoolAnimator;                   // �������� ����������
    private Animator playerAnimator;                     // �������� ������
    private float napr;
    private bool flag = true;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        whirlpoolAnimator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();

        if (transform.parent.gameObject.name == spawnHeroes.GetNamePl1())       // ���� ������ 1 �����
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
            player = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        else                                                                    // ���� ������ 2 �����
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());
            player = GameObject.Find(spawnHeroes.GetNamePl2());
        }

        playerAnimator = player.GetComponent<Animator>();
        plStEnemy = enemy.GetComponent<PlayerStatus>();
        napr = player.GetComponent<Transform>().localScale.x;
        Vector2 movement = Vector2.right * speed * Time.deltaTime * napr;
        _body.velocity = movement;
        transform.parent = null;
    }

    private void FixedUpdate()
    {
        if (flag)
        {
            Vector2 movement = Vector2.right * speed * Time.deltaTime * napr;
            _body.velocity = movement;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)                          
    {
        if (collision.name == enemy.name && !collision.isTrigger)                   // ���� ������ ����� �����������
        {
            flag = false;
            enemy.GetComponent<AnimationAbstract>().SetStan(true);
            transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z - 1);
            //plStEnemy.setJumpForce(0);
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerAnimator.SetBool("ulta_med", true);
            whirlpoolAnimator.SetBool("popal", true);
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            //plStEnemy.SetSpeed�oefficient(0);
            enemy.GetComponent<PlayerStatus>().SetStan(true);
            _body.velocity = Vector2.zero;
        }
        else if (collision.name != player.name && !collision.isTrigger)
            Destroy(gameObject);
    }

    public void Damage()
    {
        plStEnemy.TakeDamage(13);
    }

    public void EnemyLifting()                             
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 0.33f, enemy.transform.position.z);
    }

    public void WhirlpoolDestroy()
    {
        
        enemy.GetComponent<AnimationAbstract>().SetStan(false);
        playerAnimator.SetBool("ulta_med", false);
        Destroy(gameObject);
    }

    public void ExitEnemyFromWhirlpool()
    {
        enemy.GetComponent<PlayerStatus>().SetStan(false);
        enemy.GetComponent<Rigidbody2D>().gravityScale = 3;
        //plStEnemy.SetSpeed�oefficient(1);
        //plStEnemy.setJumpForce(15);
    }
}
