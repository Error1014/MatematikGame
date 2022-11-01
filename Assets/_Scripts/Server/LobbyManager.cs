using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;
    private byte maxPlayer = 10;
    [SerializeField] private GameObject SettingBlock;
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 99999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ShowSettingBlock()
    {
        SettingBlock.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = maxPlayer });
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("SampleScene");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
}
