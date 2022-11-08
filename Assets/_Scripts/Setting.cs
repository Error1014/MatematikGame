using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Setting : MonoBehaviour, IPunObservable
{
    public SettingData settingData;
    [SerializeField] private GenerationPrimer generationPrimer = new GenerationPrimer();
    private PhotonView photonView;
    private string JsonStr;
    private string path;

    #region ����� path � ����������� �� ��������� GetPath()
    private void GetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
    }
    #endregion

    #region ������ ������  ReadData()
    private void ReadData()
    {
        settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));//������ ������
    }
    #endregion

    #region ������ ������ WriteData()
    private void WriteData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(settingData));//������ ������
    }
    #endregion
    void Awake()
    {
        generationPrimer = FindObjectOfType<GenerationPrimer>();
        photonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            GetPath();
            ReadData();
            JsonStr = JsonUtility.ToJson(settingData);
        }
        if (photonView.IsMine)
        {
            Debug.Log("Good");
        }
        generationPrimer.settingData = settingData;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(JsonStr);
        }
        else
        {
            GetPath();
            JsonStr = (string)stream.ReceiveNext();
            File.WriteAllText(path, JsonStr);
            settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));
        }
    }
}
