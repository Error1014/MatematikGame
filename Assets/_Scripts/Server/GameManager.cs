using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.IO;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject settingData;
    private void Start()
    {
        PhotonNetwork.Instantiate(settingData.name, Vector2.zero, Quaternion.identity);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveLobby();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
}
