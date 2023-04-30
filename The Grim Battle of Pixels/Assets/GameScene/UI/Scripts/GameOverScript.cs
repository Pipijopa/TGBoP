using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] Capture cpt;
    [SerializeField] PauseScript pauseScr;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Image player1Label;
    [SerializeField] Image player2Label;
    private bool gameOver = false;
    private GSMenuScript gsms;

    private void Start()
    {
        gsms = GameObject.Find("HUD").GetComponent<GSMenuScript>();
    }

    private void Update()
    {
        if ((cpt.getWin() > 0) && !gameOver)
        {
            pauseScr.Pause();
            gameOverPanel.transform.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("ButtonPlayAgain"));
            gsms.setLSB(GameObject.Find("ButtonPlayAgain"));
            gameOver = true;
            if (cpt.getWin() == 1)
            {
                player1Label.transform.gameObject.SetActive(true);
            }
            else
            {
                player2Label.transform.gameObject.SetActive(true);
            }
        }
    }

    public void playAgaingBA()
    {
        //pauseScr.Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitBA()
    {
        //pauseScr.Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public bool getGameOver() { return gameOver; }
}
