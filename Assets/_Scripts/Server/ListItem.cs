using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ListItem : MonoBehaviour
{
    [SerializeField] private Text textName;
    [SerializeField] private Text textPlayerCount;

    public void SetInfo(RoomInfo info)
    {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers;   
    }

    public void JoinToListRoom()
    {
        PhotonNetwork.JoinRoom(textName.text);
    }


}
