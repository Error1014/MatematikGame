using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject TextBoxBlock;
    [SerializeField] private string region;
    [SerializeField] InputField RoomName;
    [SerializeField] ListItem itemPrefab;
    [SerializeField] Transform content;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    public void ActivTextBoxBlock()
    {
        TextBoxBlock.SetActive(true);
    }
    public void CloseTextBoBlock()
    {
        TextBoxBlock.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключились к: "+region);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Вы отключены от сервера!");
    }

    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected)return;
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 25;
        PhotonNetwork.JoinOrCreateRoom(RoomName.text,roomOptions,TypedLobby.Default);
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Создана команта: "+PhotonNetwork.CurrentRoom.Name );
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Неудалось создать комнату");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            ListItem listItem = Instantiate(itemPrefab, content);
            if (listItem!=null)
            {
                listItem.SetInfo(info);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
