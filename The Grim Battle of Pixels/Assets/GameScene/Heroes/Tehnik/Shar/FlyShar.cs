using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShar : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;                // объект SpawnHeroes
    private float speed = 800f;                     // скорость шара “ехника
    private Rigidbody2D _body;                      // физический компонент шара
    private GameObject enemy;                       // ссылка на объект протиника
    private GameObject player;                      // ссылка на объект “ехника
    private PlayerStatus EnemyStatus;               // объект класса PlayerStatus противника
    private Animator SphereAnimator;                // компонент аниматора у шара
    private float deltaY, deltaX;                   // итоговые скорости по вертикали и горизонтали
    private bool isPlayer1 = false;                 // €вл€етс€ ли игрок первым
    private Animator playerAnimator;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        SphereAnimator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
        if (player.name == spawnHeroes.GetNamePl1())    // если игрок первый
        {
            isPlayer1 = true;
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else                                            // если игрок второй
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());

        EnemyStatus = enemy.GetComponent<PlayerStatus>();
        gameObject.transform.parent = null;
    }

    private void FixedUpdate()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("death"))
        {
            Destroy(gameObject);
        }
        if (isPlayer1)
        {
            SphereAnimator.SetFloat("Horizontal", Input.GetAxis("Horizontal1"));
            SphereAnimator.SetFloat("Vertical", Input.GetAxis("Jump1"));
            deltaX = Input.GetAxis("Horizontal1") * speed * Time.deltaTime;
            deltaY = Input.GetAxis("Jump1") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, deltaY);               // придаем шару скорость
        }
        else
        {
            SphereAnimator.SetFloat("Horizontal", Input.GetAxis("Horizontal2"));
            SphereAnimator.SetFloat("Vertical", Input.GetAxis("Jump2"));
            deltaX = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
            deltaY = Input.GetAxis("Jump2") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, deltaY);               // придаем шару скорость
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)       // если попал в противника
        {
            EnemyStatus.TakeDamage(80);                                 // нанести врагу 80 урона
            player.GetComponent<Animator>().SetBool("ultaEnd", true);   // смена анимации техника
            Destroy(transform.gameObject);                              // унитожить шар
        }
        else if (collision.name != player.name && !collision.isTrigger) // если не попал в противника
        {
            player.GetComponent<Animator>().SetBool("ultaEnd", true);   // смена анимации техника
            Destroy(transform.gameObject);                              // унитожить шар
        }
    }
}
