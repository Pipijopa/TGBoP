using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTehnik : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    [SerializeField] GameObject shield;             // ������ ����
    private Animator playerAnimator;                // �������� ���������
    private Animator shieldAnimator;                // �������� ����
    private GameObject Enemy;
    private PlayerStatus enemyStatus;
    private PlayerStatus playerStatus;
    private bool isAbilityRunning = false;          // ���� ����������� �������� �����������
    private bool isAbilityComplited = true;         // ���� �������� ����������� ���������


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
                    && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)             // ���� ������ ������������
        {
            shield.SetActive(true);
            playerStatus.SetCurrentArmor(30);
            enemyStatus.TakeDamage(35);
            isAbilityRunning = false;
            StartCoroutine("isArmor");
        }
    }

    IEnumerator isArmor()                                 // ��������, ������� ���������, ���� �� � ��������� ����� �� ����
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
