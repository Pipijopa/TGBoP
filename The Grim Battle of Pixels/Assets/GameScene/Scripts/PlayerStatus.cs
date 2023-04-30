using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private Animator animator;
    private DeathCounter deathCounter;
    private CapsuleCollider2D circle;
    private SpawnHeroes spawnHeroes;
    private Rigidbody2D rb;
    private Vector2 force = Vector2.zero;
    private float speed = 500f;
    private float jumpForce = 15f;
    private bool facingRight = true;
    private bool squat = false;
    private float deltaX = 0;
    private bool isPlayer1 = false;
    private float speedCoefficient = 1;
    private float speedBustCoefficient = 1;
    private float jumpCoefficient = 1;
    private float manaSetCoefficient = 1;
    private bool proverka;
    private bool grounded = false;
    private bool forceEnemy = false;
    private bool flagJump = true;
    private int maxMana = 100;
    private int maxHeath = 100;
    private int currentMana = 0;
    private int currentHeath = 100;
    private int currentArmor = 0;
    private bool flagPoison = false;
    private bool isDeathMode = false;
    private bool stan = false;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        deathCounter = Camera.main.GetComponent<DeathCounter>();

        if (deathCounter != null)
            isDeathMode = true;

        if (name == spawnHeroes.GetNamePl1())
            isPlayer1 = true;
        else
            Flip();


        animator = GetComponent<Animator>();
        circle = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayer1)
        {
            proverka = animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") || animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ulta") || animator.GetCurrentAnimatorStateInfo(0).IsName("ability")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ability1") || animator.GetCurrentAnimatorStateInfo(0).IsName("abilityEnd")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("death") || animator.GetCurrentAnimatorStateInfo(0).IsName("reincarnation")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ulta1") || animator.GetCurrentAnimatorStateInfo(0).IsName("ultaEnd");

            Vector3 max = circle.bounds.max;
            Vector3 min = circle.bounds.min;

            Vector2 corner1 = new Vector2(max.x - .3f, min.y - .1f);
            Vector2 corner2 = new Vector2(min.x + .3f, min.y - .2f);
            Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

            if (hit != null && (!hit.isTrigger || hit.name == spawnHeroes.GetNamePl2()))
                grounded = true;
            else
                grounded = false;

            if (deltaX > 0 && !facingRight && !proverka)
                Flip();
            else if (deltaX < 0 && facingRight && !proverka)
                Flip();
        }
        else
        {
            proverka = animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") || animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ulta") || animator.GetCurrentAnimatorStateInfo(0).IsName("ability")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ability1") || animator.GetCurrentAnimatorStateInfo(0).IsName("abilityEnd")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("death") || animator.GetCurrentAnimatorStateInfo(0).IsName("reincarnation")
                                        || animator.GetCurrentAnimatorStateInfo(0).IsName("ulta1") || animator.GetCurrentAnimatorStateInfo(0).IsName("ultaEnd");
            Vector3 max = circle.bounds.max;
            Vector3 min = circle.bounds.min;

            Vector2 corner1 = new Vector2(max.x - .3f, min.y - .1f);
            Vector2 corner2 = new Vector2(min.x + .3f, min.y - .2f);
            Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

            if (hit != null && (!hit.isTrigger || hit.name == spawnHeroes.GetNamePl1()))
                grounded = true;
            else
                grounded = false;

            if (deltaX > 0 && !facingRight && !proverka)
                Flip();
            else if (deltaX < 0 && facingRight && !proverka)
                Flip();
        }
    }

    private void FixedUpdate()
    {
        if (!stan)
        {
            if (isPlayer1)
            {
                if (grounded && Input.GetAxisRaw("Jump1").Equals(1) && !squat && !proverka && flagJump)
                {
                    rb.AddForce(Vector2.up * jumpForce * jumpCoefficient, ForceMode2D.Impulse);
                    flagJump = false;
                }
                if (Input.GetAxisRaw("Jump1").Equals(0))
                    flagJump = true;
                if (Input.GetAxisRaw("Jump1").Equals(-1) && grounded && !proverka)
                    squat = true;
                else
                    squat = false;
                deltaX = Input.GetAxis("Horizontal1") * speed * speedBustCoefficient * Time.deltaTime * speedCoefficient;
                Vector2 movement = new Vector2(deltaX, rb.velocity.y);
                if (forceEnemy)
                {
                    rb.AddForce(force, ForceMode2D.Impulse);
                    force = new Vector2(0, 0);
                    forceEnemy = false;
                }
                else if (!squat && !proverka)
                    rb.velocity = movement;
                else
                    rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                if (grounded && Input.GetAxisRaw("Jump2").Equals(1) && !squat && !proverka && flagJump)
                {
                    rb.AddForce(Vector2.up * jumpForce * jumpCoefficient, ForceMode2D.Impulse);
                    flagJump = false;
                }
                if (Input.GetAxisRaw("Jump2").Equals(0))
                    flagJump = true;
                if (Input.GetAxisRaw("Jump2").Equals(-1) && grounded && !proverka)
                    squat = true;
                else
                    squat = false;
                deltaX = Input.GetAxis("Horizontal2") * speedBustCoefficient * speed * Time.deltaTime * speedCoefficient;
                Vector2 movement = new Vector2(deltaX, rb.velocity.y);
                if (forceEnemy)
                {
                    rb.AddForce(force, ForceMode2D.Impulse);
                    force = new Vector2(0, 0);
                    forceEnemy = false;
                }
                else if (!squat && !proverka)
                    rb.velocity = movement;
                else
                    rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!flagPoison)
            StartCoroutine(colr());

        if (currentArmor > 0)
        {
            if (currentArmor - damage > 0)
                currentArmor -= damage;
            else
            {
                currentHeath -= damage - currentArmor;
                currentArmor = 0;
            }
        }
        else
            currentHeath -= damage;

        if (currentHeath <= 0)
        {
            if (isDeathMode)
                deathCounter.DeathPlayer(isPlayer1);

            
            StartCoroutine(reincarnation());
        }
    }


    IEnumerator reincarnation()
    {

        animator.SetBool("die", true);
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(5f);
        rb.bodyType = RigidbodyType2D.Dynamic;

        if (isPlayer1)
            transform.position = new Vector3(-7, -5, 0);
        else
            transform.position = new Vector3(7, -5, 0);

        animator.SetBool("die", false);

        speed = 500;
        returnJump—oefficient();
        returnSpeedBust—oefficient();
        currentHeath = maxHeath;
    }

    IEnumerator colr()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
    

    public void Hill(int hp)
    {
        if (currentHeath + hp > maxHeath)
            currentHeath = maxHeath;
        else
            currentHeath += hp;
    }

    public void nullMana()
    {
        currentMana = 0;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float getCurrentHeath() { return currentHeath; }
    public int getCurrentMana() { return currentMana; }
    public int getMaxMana() { return maxMana; }
    public int getMaxHeath() { return maxHeath; }
    public bool getSquat() { return squat; }
    public float getDeltaX() { return deltaX; }

    public float getSpeed() { return speed; }
    public void setSpeed(float newSpeed) { speed = newSpeed; }
    public void setForceEnemy(bool flag) { forceEnemy = flag; }
    public void setForce(Vector2 vec) { force = vec; }
    public void setFlagPoison(bool f) { flagPoison = f; }

    public void setJumpForce(int a) { jumpForce = a;}
    public void setCurrentMana(int newMana)
    {
        if (currentMana + (int)(newMana * manaSetCoefficient) >= maxMana)
            currentMana = maxMana;
        else 
            currentMana += (int)(newMana * manaSetCoefficient);
    }

    public void SetCurrentArmor(int a)
    {
        currentArmor = a;
    }

    public int GetCurrentArmor()
    {
        return currentArmor;
    }

    public void SetSpeed—oefficient(int a)
    {
        speedCoefficient = a;
    }

    public float GetSpeed—oefficient()
    {
        return speedCoefficient;
    }

    public void SetJump—oefficient(float newCoef, int time)
    {
        jumpCoefficient = newCoef;
        Invoke("returnJump—oefficient", time);
    }

    public void returnJump—oefficient()
    {
        jumpCoefficient = 1;
    }

    public void SetSpeedBust—oefficient(float newCoef, int time)
    {
        speedBustCoefficient = newCoef;
        Invoke("returnSpeedBust—oefficient", time);
    }

    public void returnSpeedBust—oefficient()
    {
        speedBustCoefficient = 1;
    }

    public void SetManaSetCoefficient(float newCoef, int time)
    {
        manaSetCoefficient = newCoef;
        Invoke("returnManaSetCoefficient", time);
    }

    public void returnManaSetCoefficient()
    {
        manaSetCoefficient = 1;
    }

    public void SetStan(bool flag) {
        stan = flag;
    }

    public bool GetGroung()
    {
        return grounded;
    }
}
