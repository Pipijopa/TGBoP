using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class MenuScript : MonoBehaviour
{
    //public enum characterList { character1, character2, character3, character4, character5 };
    public static int P1;
    public static int P2;
    private int gameMode = 0;
    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    [SerializeField] Image P1I;
    [SerializeField] Image P2I;
   
    [SerializeField] GameObject namesAuthors;
    [SerializeField] GameObject linksAuthors;

    private bool authorSwitch = true;

    private GameObject lastSelectedButton;

    public int getP1() { return P1; }
    public int getP2() { return P2; }

    //P1 - true; P2 - flase
    public void CharacterChooseP1Button(int chrP)
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl2"));
        lastSelectedButton = GameObject.Find("Charecter1pl2");
        P1 = chrP;
        P1I.sprite = HeroesIcons[P1];
    }

    public void CharacterChooseP1ButtonRandom()
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl2"));
        lastSelectedButton = GameObject.Find("Charecter1pl2");
        P1 = Random.Range(0, 5);
        P1I.sprite = HeroesIcons[P1];
    }

    public void CharacterChooseP2Button(int chrP)
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("StartPlayButton"));
        lastSelectedButton = GameObject.Find("StartPlayButton");
        P2 = chrP;
        P2I.sprite = HeroesIcons[P2];
    }

    public void CharacterChooseP2ButtonRandom()
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("StartPlayButton"));
        lastSelectedButton = GameObject.Find("StartPlayButton");
        P2 = Random.Range(0, 5);
        P2I.sprite = HeroesIcons[P2];
    }

    public void SetModeButton(int numberScene)
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl1"));
        lastSelectedButton = GameObject.Find("Charecter1pl1");
        gameMode = numberScene;
    }


    public void PlayGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + gameMode);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ForSelectButton(GameObject s)
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = s;
        EventSystem.current.SetSelectedGameObject(s);
        lastSelectedButton = s;
    }

    public void AuthorSwitchButton()
    {
        if (authorSwitch)
        {
            namesAuthors.SetActive(false);
            linksAuthors.SetActive(true);
            authorSwitch = !authorSwitch;
        }
        else
        {
            namesAuthors.SetActive(true);
            linksAuthors.SetActive(false);
            authorSwitch = !authorSwitch;
        }
    }

    public void Awake()
    {
        //P1I = GameObject.Find("MImageP1").GetComponent<Image>();
        //P2I = GameObject.Find("MImageP2").GetComponent<Image>();
    }

    public void Start()
    {
        //GameObject.Find("PlayMenu").SetActive(false);
        //GameObject.Find("ChooseMenu").transform.GetChild(2).gameObject.SetActive(false);
        //GameObject.Find("ChooseMenu").SetActive(false);
        //GameObject.Find("MainMenu").transform.GetChild(0).gameObject.GetComponent<Button>().Select();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedButton);
        }
    }

    public void setLSB(GameObject LSB)
    {
        lastSelectedButton = LSB;
    }
}
