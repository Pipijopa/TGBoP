using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritFly : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Transform transform1;
    private Animator animator;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;
    private bool isTriggeredMeteor = true;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        plSt1 = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
        transform1 = GetComponent<Transform>();
        StartCoroutine("MeteorFly");
    }
    IEnumerator MeteorFly()
    {
        for (;isTriggeredMeteor;)
        {
            transform1.position = new Vector3(transform1.position.x, transform.position.y - 0.2f, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl1())
        {
            plSt1.TakeDamage(100);
            Destroy(gameObject);
        }
        if (collision != null && !collision.isTrigger && collision.name == spawnHeroes.GetNamePl2())
        {
            plSt2.TakeDamage(100);
            Destroy(gameObject);
        }
        if (!collision.isTrigger && collision.tag == "Ground")
        {
            animator.SetBool("Death", true);
            isTriggeredMeteor = false;
        }

    }


    public void Des()
    {
        Destroy(gameObject);
    }
}
