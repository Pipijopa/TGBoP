using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{
    private bool[] P1effects = new bool[4]; // volshbstvo - 0; dd - 1; dj - 2; haste - 3
    private float[] P1effectsTimer = new float[4];
    [SerializeField] Image[] P1efim = new Image[4];
    private bool[] P2effects = new bool[4];
    private float[] P2effectsTimer = new float[4];
    [SerializeField] Image[] P2efim = new Image[4];

    private const float BANKA_TIME = 10f;

    void Start()
    {
        for (int i = 0; i < 4; ++i)
        {
            P1effects[i] = false;
            P2effects[i] = false;

            P1effectsTimer[i] = BANKA_TIME;
            P2effectsTimer[i] = BANKA_TIME;
        }
    }

    void Update()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (P1effects[i])
            {
                P1efim[i].gameObject.SetActive(true);
                P1effectsTimer[i] -= Time.deltaTime;

                if (P1effectsTimer[i] <= 0)
                    P1effects[i] = false;
            }
            else
            {
                P1efim[i].gameObject.SetActive(false);
                P1effectsTimer[i] = BANKA_TIME;
            }


            if (P2effects[i])
            {
                P2efim[i].gameObject.SetActive(true);
                P2effectsTimer[i] -= Time.deltaTime;

                if (P2effectsTimer[i] <= 0)
                    P2effects[i] = false;
            }
            else
            {
                P2efim[i].gameObject.SetActive(false);
                P2effectsTimer[i] = BANKA_TIME;
            }
        }
    }

    public void bankiP1(int i)
    {
        P1effects[i] = true;
    }

    public void bankiP2(int i)
    {
        P2effects[i] = true;
    }
}
