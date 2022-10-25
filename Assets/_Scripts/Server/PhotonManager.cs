using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UIElements;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject TextBoxBlock;
    [SerializeField] private string region;
    [SerializeField] InputField RoomName;
    [SerializeField] ListItem itemPrefab;
    [SerializeField] Transform content;
    [SerializeField] GameObject settingBlock;

    List<RoomInfo> allRoomsInfo = new List<RoomInfo>();
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    public void ActivTextBoxBlock()
    {
        TextBoxBlock.SetActive(true);
    }
    public void CloseTextBlock()
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
            for (int i = 0; i < allRoomsInfo.Count; i++)
            {
                if (allRoomsInfo[i].masterClientId==info.masterClientId)
                {
                    return;
                }
            }
            ListItem listItem = Instantiate(itemPrefab, content);
            if (listItem!=null)
            {
                listItem.SetInfo(info);
                allRoomsInfo.Add(info);
            }
        }
    }

    public void OnSettinLevel()
    {
        settingBlock.SetActive(true);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }

    //выход из комнаты
    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
