using UnityEngine;
using System.Collections;

public class AnimationDed : AnimationAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private Animator animatorPepel;
    private Rigidbody2D rb;
    private PlayerStatus plSt;
    private BoxCollider2D box;
    private bool isPlayer1;
    private bool isAbilityReady = true;
    private float time = 0;
    private float timeBusterCoefficient = 1;
    private bool isAbilityRunning = true;
    private bool stan = false;


    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        box = GetComponent<BoxCollider2D>();
        animatorPepel = gameObject.transform.GetChild(0).GetComponent<Animator>();
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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick"))
            box.enabled = false;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))
            plSt.nullMana();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && isAbilityRunning)
        {
            isAbilityReady = false;
            StartCoroutine("timeAbility");
            isAbilityRunning = false;

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

                    if (Input.GetAxisRaw("Ability1").Equals(1) && isAbilityReady)
                        animator.SetBool("ability", true);
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

                    if (Input.GetAxisRaw("Ability2").Equals(1) && isAbilityReady)
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
    }

    IEnumerator timeAbility()
    {
        while (time < 9)
        {
            yield return new WaitForSeconds(0.25f);
            time += 0.25f * timeBusterCoefficient;
        }
        time = 0;
        isAbilityReady = true;
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

    public void OffAsh()
    {
        if (transform.localScale.x == -1)
        {
            Vector3 theScale = transform.GetChild(0).GetComponent<Transform>().localScale;
            theScale.x *= -1;
            transform.GetChild(0).GetComponent<Transform>().localScale = theScale;
        }
        animatorPepel.SetBool("Death", true);
    }

    public void OnAsh()
    {
        if (transform.localScale.x == -1)
        {
            Vector3 theScale = transform.GetChild(0).GetComponent<Transform>().localScale;
            theScale.x *= -1;
            transform.GetChild(0).GetComponent<Transform>().localScale = theScale;
        }
        animatorPepel.SetBool("Death", false);
    }

    public void OnChains()
    {
        transform.GetChild(1).gameObject.SetActive(true);
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
