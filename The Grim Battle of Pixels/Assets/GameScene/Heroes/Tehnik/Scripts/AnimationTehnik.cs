using UnityEngine;
using System.Collections;

public class AnimationTehnik : AnimationAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private PlayerStatus plSt;
    private bool isPlayer1;
    private bool flagAbility = true;
    private float time = 0;
    private float timeBusterCoefficient = 1;
    private Transform UltaPosition;
    [SerializeField] GameObject sphere;
    private bool isAbilityReady = true;
    private bool stan = false;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        box = GetComponent<BoxCollider2D>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())       // если первый игрок
            isPlayer1 = true;
        else                                        // если второй игрок
            isPlayer1 = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick"))      // если не бьем отключаем коллайдер, отвечающий за урон
            box.enabled = false;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))             // если активирована ульта, обнуляем запас маны
            plSt.nullMana();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && isAbilityReady)        //  если использована способность, включаем её перезарядку
        {
            flagAbility = false;
            StartCoroutine("timeAbility");
            isAbilityReady = false;

        }
        if (isPlayer1)
        {
            if (!plSt.getSquat())                           // если персонаж не сидит
            {
                animator.SetBool("squat", false);

                if (Input.GetAxisRaw("Kick1").Equals(-1))
                {
                    animator.SetBool("top_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("top_kick", false);

                if (Input.GetAxisRaw("Kick1").Equals(1))
                {
                    animator.SetBool("bottom_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("bottom_kick", false);

                if (Input.GetAxisRaw("Ability1").Equals(-1) && plSt.getCurrentMana() == 100)
                {
                    animator.SetBool("ulta", true);
                    animator.SetBool("ultaEnd", false);
                }
                else
                    animator.SetBool("ulta", false);

                if (Input.GetAxisRaw("Ability1").Equals(1) && flagAbility)
                    animator.SetBool("ability", true);
                else
                    animator.SetBool("ability", false);

                animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));


                animator.SetFloat("velocity_Y", rb.velocity.y);
            }
            else
                animator.SetBool("squat", true);                // если персонаж сидит
        }
        else
        {
            if (!plSt.getSquat())
            {
                animator.SetBool("squat", false);

                if (Input.GetAxisRaw("Kick2").Equals(-1))
                {
                    animator.SetBool("top_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("top_kick", false);

                if (Input.GetAxisRaw("Kick2").Equals(1))
                {
                    animator.SetBool("bottom_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("bottom_kick", false);

                if (Input.GetAxisRaw("Ability2").Equals(-1) && plSt.getCurrentMana() == 100)
                {
                    animator.SetBool("ulta", true);
                    animator.SetBool("ultaEnd", false);
                }
                else
                    animator.SetBool("ulta", false);

                if (Input.GetAxisRaw("Ability2").Equals(1) && flagAbility)
                    animator.SetBool("ability", true);
                else
                    animator.SetBool("ability", false);

                animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));

                animator.SetFloat("velocity_Y", rb.velocity.y);
            }
            else
                animator.SetBool("squat", true);
        }
    }

    IEnumerator timeAbility()                           // корутина, отвечающая за перезарядку способностей
    {
        while (time < 9)
        {
            yield return new WaitForSeconds(0.25f);
            time += 0.25f * timeBusterCoefficient;
        }
        time = 0;
        flagAbility = true;
        isAbilityReady = true;
    }

    override
    public float getTime()
    {
        return time;
    }

    override
    public bool getFlagAbility()
    {
        return flagAbility;
    }

    public void SphereSpawn()                                     // создание объекта шара
    {
        UltaPosition = transform.GetChild(0).transform;
        GameObject sphereObject = Instantiate(sphere, UltaPosition.position, UltaPosition.rotation);
        sphereObject.transform.parent = transform;
    }

    override
    public void SetTimeBusterCoefficient(float newCoef, int time)
    {
        timeBusterCoefficient = newCoef;
        Invoke("returnTimeBusterCoefficient", time);
    }

    private void returnTimeBusterCoefficient()
    {
        timeBusterCoefficient = 1;
    }

    override
    public void SetStan(bool flag)
    {
        stan = flag;
    }
}
