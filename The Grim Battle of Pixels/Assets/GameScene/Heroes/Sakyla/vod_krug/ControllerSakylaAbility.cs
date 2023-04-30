using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSakylaAbility : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private GameObject enemy;
    private PlayerStatus plStEnemy;
    private int abilityDamage = 30;
    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        
        if (transform.parent.name == spawnHeroes.GetNamePl1())
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        else
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());

        plStEnemy = enemy.GetComponent<PlayerStatus>();
        transform.parent = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(abilityDamage);
        }
    }
    void waterTraceOff() {                        // функция, уничтожающая водный шлейф
        Destroy(gameObject);
    }
}
