using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Setting : MonoBehaviour
{
    public SettingData settingData;
    [SerializeField] private GenerationPrimer generationPrimer = new GenerationPrimer();
    private PhotonView photonView;
    private string JsonStr;
    private string path;

    #region выбор path в зависимости от платформы GetPath()
    private void GetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
    }
    #endregion

    #region чтение данных  ReadData()
    private void ReadData()
    {
        settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));//чтение данных
    }
    #endregion

    #region запись данных WriteData()
    private void WriteData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(settingData));//запись данных
    }
    #endregion
    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            GetPath();
            ReadData();
            JsonStr = JsonUtility.ToJson(settingData);
            Debug.Log(JsonStr);
            SendDataSetting();
        }
        generationPrimer = FindObjectOfType<GenerationPrimer>();
        generationPrimer.settingData = settingData;
    }
    public static UnityEvent SetDataSetting= new UnityEvent();
    public void SendDataSetting()
    {
        photonView.RPC("Send", RpcTarget.AllBufferedViaServer,JsonStr);
        Debug.Log("Отправленно");
    }
    [PunRPC]
    public void Send(string json)
    {
        settingData = JsonUtility.FromJson<SettingData>(json);
        generationPrimer.settingData = settingData;
        SetDataSetting.Invoke();
        Debug.Log("Получено");
    }
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        JsonStr = JsonUtility.ToJson(settingData);
    //        stream.SendNext(JsonStr);
    //        Debug.Log(JsonStr);
    //    }
    //    else
    //    {
    //        JsonStr = (string)stream.ReceiveNext();
    //        JsonUtility.FromJsonOverwrite(JsonStr, settingData);
    //    }
    //}

    //public void OnConnectedToMaster()
    //{
    //    throw new System.NotImplementedException();
    //}


}
