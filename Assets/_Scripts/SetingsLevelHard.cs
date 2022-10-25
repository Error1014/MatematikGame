using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetingsLevelHard : MonoBehaviour
{
    public bool isTimeBar;
    public bool isOtricNumb;

    public bool isPlus;
    public bool isMinus;
    public bool isUmnoj;
    public bool isDelen;

    public int minNumb;
    public int maxNumb;

    public static SettingData settingData = new SettingData();
    private string path;

    [SerializeField] private SwichToggleIsTimeBar IsTimeBar;
    [SerializeField] private SwichToggleIsOtric IsOtric;
    [SerializeField] private SelectOperationToggle SelectOperation;
    [SerializeField] WriteNumbText writeNumbText;

    public InfoMessage info;

    //settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));//чтение данных
    //File.WriteAllText(path, JsonUtility.ToJson(settingData));//запись данных
    #region выбор path в зависимости от платформы
    private void GetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
    }
    #endregion

    #region чтение данных
    private void ReadData()
    {
        settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(path));//чтение данных
    }
    #endregion

    #region запись данных
    private void WriteData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(settingData));//запись данных
    }
    #endregion

    void Awake()
    {
        GetPath();
        
        if (File.Exists(path))
        {
            ReadData();
        }
        IsTimeBar.isTimeBar = settingData.isTimeBar;
        IsOtric.isOtric = settingData.isOtricNumb;
        SelectOperation.isPlus = settingData.isPlus;
        SelectOperation.isMinus = settingData.isMinus;
        SelectOperation.isUmnoj = settingData.isUmnoj;
        SelectOperation.isDelen = settingData.isDelen;
        writeNumbText.minNumb = settingData.minNumb;
        writeNumbText.maxNumb = settingData.maxNumb;
        Debug.Log(settingData.minNumb);
        Debug.Log(settingData.maxNumb);

        //SwichTogle.EventToggle.AddListener(SetDataSettings);
    }
    public void SetSettings()
    {
        isTimeBar = IsTimeBar.isTimeBar;
        isOtricNumb = IsOtric.isOtric;
        isPlus = SelectOperation.isPlus;
        isMinus = SelectOperation.isMinus;
        isUmnoj = SelectOperation.isUmnoj;
        isDelen = SelectOperation.isDelen;
        minNumb = writeNumbText.minNumb;
        maxNumb = writeNumbText.maxNumb;

        //SetDataSettings();
    }
    public void SaveDataSettings()
    {
        settingData.isTimeBar = IsTimeBar.isTimeBar;
        settingData.isOtricNumb = IsOtric.isOtric;
        if (!IsProverkaSelectOperation()) return;
        else
        {
            settingData.isPlus = SelectOperation.isPlus;
            settingData.isMinus = SelectOperation.isMinus;
            settingData.isUmnoj = SelectOperation.isUmnoj;
            settingData.isDelen = SelectOperation.isDelen;
        }
        if (!IsProverkaMinMaxNumb()) return;
        else
        {
            settingData.minNumb = writeNumbText.minNumb;
            settingData.maxNumb = writeNumbText.maxNumb;
        }
        WriteData();
    }

    private bool IsProverkaSelectOperation()
    {
        if (SelectOperation.isPlus == false &&
            SelectOperation.isMinus == false &&
            SelectOperation.isUmnoj == false &&
            SelectOperation.isDelen == false)
        {
            info.gameObject.SetActive(true);
            info.ShowInfo("Ќеобходимо выбратать хот€бы один пункт!");
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool IsProverkaMinMaxNumb()
    {
        if (minNumb>=maxNumb)
        {
            info.gameObject.SetActive(true);
            info.ShowInfo("Ќеобходимо выбрать минимальное число меньше максимального!");
            return false;
        }
        else if ((IsOtric.isOtric==false) && (writeNumbText.minNumb < 0|| writeNumbText.maxNumb < 0))
        {
            info.gameObject.SetActive(true);
            info.ShowInfo("ќтрицательные числа запрещены");
            return false;
        }
        else
        {
            return true;
        }
    }









}

[Serializable]
public class SettingData
{
    public bool isTimeBar;
    public bool isOtricNumb;
    public int minNumb;
    public int maxNumb;

    public bool isPlus;
    public bool isMinus;
    public bool isUmnoj;
    public bool isDelen;
}



