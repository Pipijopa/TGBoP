using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClassicGaveOver : MonoBehaviour
{
    [SerializeField] DeathCounter dc;
    [SerializeField] ClassicPauseScript pauseScr;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Image player1Label;
    [SerializeField] Image player2Label;
    private bool gameOver = false;
    [SerializeField] Image[] hearthsP1 = new Image[3];
    [SerializeField] Image[] hearthsP2 = new Image[3];
    private GSMenuScript gsms;

    private void gameOverClassic(bool playerB)
    {
        pauseScr.Pause();
        gameOverPanel.transform.gameObject.SetActive(true);
        if (!playerB)
            player1Label.gameObject.SetActive(true);
        else
            player2Label.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("ButtonPlayAgain"));
        gsms.setLSB(GameObject.Find("ButtonPlayAgain"));
        gameOver = true;
        
    }

    
    void Update()
    {
        if (gameOver)
        {

        }
        else
        {

            switch (dc.getDCP1())
            {
                case 1:
                    hearthsP1[2].gameObject.SetActive(false);
                    break;
                case 2:
                    hearthsP1[1].gameObject.SetActive(false);
                    break;
                case 3:
                    hearthsP1[0].gameObject.SetActive(false);
                    gameOver = true;
                    gameOverClassic(true);
                    break;
                default:
                    break;
            }

            switch (dc.getDCP2())
            {
                case 1:
                    hearthsP2[2].gameObject.SetActive(false);
                    break;
                case 2:
                    hearthsP2[1].gameObject.SetActive(false);
                    break;
                case 3:
                    hearthsP2[0].gameObject.SetActive(false);
                    gameOver = true;
                    gameOverClassic(false);
                    break;
                default:
                    break;
            }
        }
    }

    public void playAgaingBA()
    {
        pauseScr.Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitBA()
    {
        //pauseScr.Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public bool getGameOver() { return gameOver; }
}
