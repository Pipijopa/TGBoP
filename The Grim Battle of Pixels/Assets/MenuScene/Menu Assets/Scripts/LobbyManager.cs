using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
//using System;
//using System.Text;
//using System.Linq;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text JoinError;
    [SerializeField] private Text CreateError;
    [SerializeField] private Text NameError;
    [SerializeField] private Text LogText;
    [SerializeField] private InputField JoinField;
    [SerializeField] private InputField CreateField;
    [SerializeField] private InputField NameField;
    [SerializeField] private GameObject onlineMenu;
    [SerializeField] private GameObject title;
    private PhotonView photonView;
    public static int P1 = 5;
    public static int P2 = 5;
    [SerializeField] Image P1I;
    [SerializeField] Image P2I;
    [SerializeField] Sprite[] HeroesIcons = new Sprite[6];
    private string roomID = "";
    private bool host = false;
    private bool plReady = false;
    private bool connectedToMaster = false;
    private bool neqName = true;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        connectedToMaster = true;
        Log("Connected to Master");
    }

    public void ButtonCr(GameObject s)
    {
        PhotonNetwork.NickName = NameField.text;
        Log(PhotonNetwork.NickName);
        if (PhotonNetwork.NickName != "" && connectedToMaster)
        {
            NameField.transform.parent.gameObject.SetActive(false);
            CreateField.transform.parent.gameObject.SetActive(true);
            // костыли от артема
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(s);
            // конец костылей
        }
        else if (PhotonNetwork.NickName == "")
            NameError.text = "Enter Name";


    }

    public void ButtonJ(GameObject s)
    {
        PhotonNetwork.NickName = NameField.text;
        Log(PhotonNetwork.NickName);
        if (PhotonNetwork.NickName != "" && connectedToMaster)
        {
            NameField.transform.parent.gameObject.SetActive(false);
            JoinField.transform.parent.gameObject.SetActive(true);
            // костыли от артема
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(s);
            // конец костылей
        }
        // это тоже артем добавил
        else if (PhotonNetwork.NickName == "")
            NameError.text = "Enter Name";
    }

    public void CreateRoom(GameObject s)
    {
        if (connectedToMaster && CreateField.textComponent.text != "")
        {
            host = true;
            roomID = CreateField.textComponent.text;
            Log(roomID);
            // костыли от артема
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(s);
            // конец костылей
            PhotonNetwork.CreateRoom(roomID, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        }
        else
            JoinError.text = "Enter the room Name";
    }

    public void JoinRoom(GameObject s)
    {
        if (connectedToMaster && JoinField.textComponent.text != "")
        {
            string inputRoomID = JoinField.textComponent.text;
            Log(inputRoomID);
            // костыли от артема
            
            // конец костылей
            if (PhotonNetwork.JoinRoom(inputRoomID) == false) 
                JoinError.text = "Room Name label is empty";
            
        }
        else
            JoinError.text = "Enter the room Name";
    }


    public override void OnJoinedRoom()
    {
        if (!host && PhotonNetwork.PlayerList[0].NickName == PhotonNetwork.NickName)
        {
            PhotonNetwork.LeaveRoom();
            neqName = false;
            JoinError.text = "Nicknames are repeated";
        }
        else
        {
            neqName = true;
        }

        if (host && neqName)
        {
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
            onlineMenu.transform.GetChild(1).gameObject.SetActive(false);
            onlineMenu.transform.GetChild(5).gameObject.SetActive(true);
            photonView = PhotonView.Get(this);
            StartCoroutine("Baty");
        } 
        else if(neqName)
        {
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
            onlineMenu.transform.GetChild(2).gameObject.SetActive(false);
            photonView = PhotonView.Get(this);
            StartCoroutine("Baty");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateError.text = message;
    }
    

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        JoinError.text = message;
    }

    private void Log(string asf)
    {
        Debug.Log(asf);
        LogText.text += "\n";
        LogText.text += asf;
    }

    public void Select(int chrP)
    {
        if (host)
        {
            photonView.RPC("Send_Hero", PhotonNetwork.PlayerList[1], (object)chrP);
            P1 = chrP;
            P1I.sprite = HeroesIcons[P1];
        }
        else
        {
            photonView.RPC("Send_Hero", PhotonNetwork.PlayerList[0], (object)chrP);
            P2 = chrP;
            P2I.sprite = HeroesIcons[P2];
        }
        onlineMenu.transform.GetChild(4).gameObject.SetActive(true);
        StartCoroutine("Qwer");
    }

    [PunRPC]
    public void Send_Hero(int a)
    {
        if (host)
            P2 = a;
        else
            P1 = a;
    }

    IEnumerator Baty()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                onlineMenu.transform.GetChild(3).gameObject.SetActive(true);
                onlineMenu.transform.GetChild(5).gameObject.SetActive(false);
                break;
            }
        }
    }

    IEnumerator Qwer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (P1 != 5 && P2 != 5)
            {
                if (host)
                {
                    P2I.sprite = HeroesIcons[P2];
                }
                else
                {
                    P1I.sprite = HeroesIcons[P1];
                }
                break;
            }
        }
    }

    public void LeaveRoomButton()
    {
        P1I.sprite = HeroesIcons[4];
        P2I.sprite = HeroesIcons[4];
        if (host)
        {
            photonView.RPC("LeaveRoomPl", PhotonNetwork.PlayerList[1]);
        }
        else
        {
            photonView.RPC("LeaveRoomPl", PhotonNetwork.PlayerList[0]);
        }
        roomID = "";
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    public void LeaveRoomPl()
    {
        roomID = "";
        PhotonNetwork.LeaveRoom();
        onlineMenu.transform.GetChild(3).gameObject.SetActive(false);
        onlineMenu.transform.GetChild(4).gameObject.SetActive(false);
        onlineMenu.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void PlayerReady()
    {
        if (host)
        {
            onlineMenu.transform.GetChild(4).transform.GetChild(6).gameObject.SetActive(true);
            photonView.RPC("SetReady", PhotonNetwork.PlayerList[1]);
            StartCoroutine("StartMatch");
        }
        else
        {
            onlineMenu.transform.GetChild(4).transform.GetChild(7).gameObject.SetActive(true);
            photonView.RPC("SetReady", PhotonNetwork.PlayerList[0]);
        }
    }

    IEnumerator StartMatch()
    {
        while (true)
        {
            if (plReady)
            {
                PhotonNetwork.LoadLevel("OnlineGameScene");
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    [PunRPC]
    private void SetReady()
    {
        plReady = true;
        if (host)
        {
            onlineMenu.transform.GetChild(4).transform.GetChild(7).gameObject.SetActive(true);
        }
        else
        {
            onlineMenu.transform.GetChild(4).transform.GetChild(6).gameObject.SetActive(true);

        }
    }

    public void Button3()
    {
        PhotonNetwork.LeaveRoom();
        StopCoroutine("Baty");
        //GameObject.Find("Title").SetActive(true);
        // костыли от артема
        if (onlineMenu.transform.GetChild(1).gameObject.activeSelf == false)
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(onlineMenu.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject);
        else
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(onlineMenu.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject);

        title.SetActive(true);
        // конец костылей
    }

    public int GetP1()
    {
        return P1;
    }

    public int GetP2()
    {
        return P2;
    }
}
