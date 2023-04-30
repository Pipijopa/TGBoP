using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassicPauseScript : MonoBehaviour
{
    private bool gamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] ClassicGaveOver gov;
    private GSMenuScript gsms;

    private void Start()
    {
        gsms = GameObject.Find("HUD").GetComponent<GSMenuScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gov.getGameOver())
        {
            if (!gamePaused)
            {
                pauseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("ButtonResume"));
                gsms.setLSB(GameObject.Find("ButtonResume"));
                Pause();
            }
        }
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        Resume();
    }


    public void Pause()
    {
        gamePaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {

        gamePaused = false;
        Time.timeScale = 1f;

    }

    public bool getGamePaused() { return gamePaused; }
}
