using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSakyla : AnimationAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    [SerializeField] GameObject waterTraceObject;
    [SerializeField] GameObject whirlpoolObject;
    private Rigidbody2D rb;
    private BoxCollider2D box;              // коллайдер, отвечающий за удары сакулы
    private PlayerStatus plSt;
    private bool isPlayer1;
    private bool isAbilityReady = false;
    private float time = 0;
    private float timeBusterCoefficient = 1;
    private bool isAbilityRunning = true;
    private bool stan = false;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        box = GetComponent<BoxCollider2D>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
            isPlayer1 = true;
        else
            isPlayer1 = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !animator.GetCurrentAnimatorStateInfo(0).IsName("botton_kick"))
            box.enabled = false;


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))
            plSt.nullMana();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && isAbilityRunning)
        {
            StartCoroutine("timeAbility");
            isAbilityRunning = false;
            WaterTraceSpawn();
            transform.position = new Vector3(transform.position.x + 4 * transform.localScale.x, transform.position.y, transform.position.z);

        }


        if (!stan)
        {
            if (isPlayer1)
            {
                if (!plSt.getSquat())
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
                    }
                    else
                        animator.SetBool("ulta", false);

                    if (Input.GetAxisRaw("Ability1").Equals(1) && isAbilityRunning)
                    {
                        animator.SetBool("ability", true);
                    }
                    else
                        animator.SetBool("ability", false);

                    animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));


                    animator.SetFloat("velocity_Y", rb.velocity.y);
                }
                else
                    animator.SetBool("squat", true);
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
                    }
                    else
                        animator.SetBool("ulta", false);

                    if (Input.GetAxisRaw("Ability2").Equals(1) && isAbilityRunning)
                    {
                        animator.SetBool("ability", true);
                    }
                    else
                        animator.SetBool("ability", false);

                    animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));

                    animator.SetFloat("velocity_Y", rb.velocity.y);
                }
                else
                    animator.SetBool("squat", true);
            }
        }
    }

    IEnumerator timeAbility()
    {
        while (time < 10)
        {
            yield return new WaitForSeconds(0.25f);
            time += 0.25f * timeBusterCoefficient;
        }
        time = 0;
        isAbilityRunning = true;
    }

    override
    public float getTime()
    {
        return time;
    }

    override
    public bool getFlagAbility()
    {
        return isAbilityReady;
    }

    public void WaterTraceSpawn()
    {
        GameObject waterTrace = Instantiate(this.waterTraceObject, new Vector3(transform.position.x - 2 * transform.localScale.x, transform.position.y, transform.position.z), Quaternion.identity);
        waterTrace.transform.parent = transform;
    }

    public void WhirlpoolSpawn()
    {
        GameObject whirlpool = Instantiate(this.whirlpoolObject, transform.GetChild(0).position, Quaternion.identity);
        whirlpool.transform.localScale = transform.localScale;
        whirlpool.transform.parent = transform;
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
