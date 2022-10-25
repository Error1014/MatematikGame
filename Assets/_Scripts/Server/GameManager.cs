using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text textLastMessage;
    private PhotonView photonView;
    public static SettingData settingData;
    private string path;

    #region ����� path � ����������� �� ���������
    private void GetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
    }
    #endregion

    #region ������ ������
    private void ReadData()
{
        settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));//������ ������
    }
    #endregion

    #region ������ ������
    private void WriteData()
{
File.WriteAllText(path, JsonUtility.ToJson(settingData));//������ ������
    }
    #endregion

    void Awake()
    {
        GetPath();

        if (File.Exists(path))
        {
            ReadData();
        }
    }

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void Send()
    {
        photonView.RPC("Send_Data", RpcTarget.AllBuffered, settingData);
    }
    [PunRPC]
    private void Send_Data(SettingData settingData)
    {
        Debug.Log(settingData.maxNumb);
    }
}
