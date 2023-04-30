using System.Collections;
using UnityEngine;

public class Capture : MonoBehaviour
{
    private Animator animator;
    private SpawnHeroes spawnHeroes;
    private string Player1;
    private string Player2;
    private float time1 = 0;
    private float time2 = 0;
    private int count = 0;
    private int time_win = 25;
    private bool flagP1 = true;
    private bool flagP2 = true;
    private bool pl1 = false;
    private bool pl2 = false;
    private int win = 0; // 0 - nobody; 1 - player1; 2 - player2



    public void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(time1 == time_win)
            win = 1;
        if(time2 == time_win)
            win = 2;

        if (count != 1)
        {
            animator.SetBool("flag", false);
            StopAllCoroutines();
            flagP1 = true;
            flagP2 = true;
        }
        else if (pl1 && flagP1)
        {
            StartCoroutine("Player1CaptFlag");
            flagP1 = false;
        }
        else if (pl2 && flagP2)
        {
            StartCoroutine("Player2CaptFlag");
            flagP2 = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 && !collision.isTrigger) {
            pl1 = true;
            count++;
        }
        if (collision.name == Player2 && !collision.isTrigger)
        {
            pl2 = true;
            count++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == Player1 && !collision.isTrigger)
            pl1 = true;
        if (collision.name == Player2 && !collision.isTrigger)
            pl2 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == Player1 && !collision.isTrigger)
        {
            pl1 = false;
            count--;
            animator.SetBool("flag", false);
            StopCoroutine("Player1CaptFlag");
            flagP1 = true;
        }
        if (collision.name == Player2 && !collision.isTrigger)
        {
            pl2 = false;
            count--;
            animator.SetBool("flag", false);
            StopCoroutine("Player2CaptFlag");
            flagP2 = true;
        }
    }




    IEnumerator Player1CaptFlag()
    {
        animator.SetBool("flag", true);
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            time1 += 0.25f;
        }
    }
    IEnumerator Player2CaptFlag()
    {
        animator.SetBool("flag", true);
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            time2 += 0.25f;
        }
    }

    public float getTime1() { return time1; }
    public float getTime2() { return time2; }
    public int getWin() { return win; }
}

