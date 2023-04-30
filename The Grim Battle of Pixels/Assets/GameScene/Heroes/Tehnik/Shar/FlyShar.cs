using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShar : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;                // ������ SpawnHeroes
    private float speed = 800f;                     // �������� ���� �������
    private Rigidbody2D _body;                      // ���������� ��������� ����
    private GameObject enemy;                       // ������ �� ������ ���������
    private GameObject player;                      // ������ �� ������ �������
    private PlayerStatus EnemyStatus;               // ������ ������ PlayerStatus ����������
    private Animator SphereAnimator;                // ��������� ��������� � ����
    private float deltaY, deltaX;                   // �������� �������� �� ��������� � �����������
    private bool isPlayer1 = false;                 // �������� �� ����� ������
    private Animator playerAnimator;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        SphereAnimator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
        if (player.name == spawnHeroes.GetNamePl1())    // ���� ����� ������
        {
            isPlayer1 = true;
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else                                            // ���� ����� ������
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
            _body.velocity = new Vector2(deltaX, deltaY);               // ������� ���� ��������
        }
        else
        {
            SphereAnimator.SetFloat("Horizontal", Input.GetAxis("Horizontal2"));
            SphereAnimator.SetFloat("Vertical", Input.GetAxis("Jump2"));
            deltaX = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
            deltaY = Input.GetAxis("Jump2") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, deltaY);               // ������� ���� ��������
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)       // ���� ����� � ����������
        {
            EnemyStatus.TakeDamage(80);                                 // ������� ����� 80 �����
            player.GetComponent<Animator>().SetBool("ultaEnd", true);   // ����� �������� �������
            Destroy(transform.gameObject);                              // ��������� ���
        }
        else if (collision.name != player.name && !collision.isTrigger) // ���� �� ����� � ����������
        {
            player.GetComponent<Animator>().SetBool("ultaEnd", true);   // ����� �������� �������
            Destroy(transform.gameObject);                              // ��������� ���
        }
    }
}
