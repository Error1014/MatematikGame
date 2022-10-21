using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonVariant : MonoBehaviour
{
    [SerializeField] private Color[] myColor;
    public static UnityEvent NextPrimerEvent = new UnityEvent();
    public static UnityEvent StartClickEvent = new UnityEvent();
    public static UnityEvent NoRightClickEvent = new UnityEvent();
    private Button SelectButton;
    private bool isEnable = true;

    private string path;
    SettingData settingData = new SettingData();


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


    private void Start()
    {
        GetPath();

        if (File.Exists(path))
        {
            ReadData();
        }
    }
    public void OnClickVariant(Button button)
    {
        SelectButton = button;
        TimeBar.AddTimeOfBar.AddListener(UpdateDataButtons);
        if (isEnable)
        {
            isEnable = false;
            Image img = SelectButton.GetComponent<Image>();
            if (SelectButton.GetComponentInChildren<Text>().text == GenerationPrimer.RightOtv.ToString())
            {
                img.color = myColor[1];
                StartClickEvent.Invoke();
                
                if (!settingData.isTimeBar)
                {
                    StartCoroutine(GenerationPrimerIsTimeBarFalse());
                }
                //StartCoroutine(PauseOfNestPrimer(button));
            }
            else
            {
                img.color = myColor[2];
                StartCoroutine(PauseOfGameOver());
            }
            
        }
    }
    private void GetNoColorButton()
    {
        Image img = SelectButton.GetComponent<Image>();
        img.color = myColor[0];
    }
    private void UpdateDataButtons()
    {
        NextPrimerEvent.Invoke();
        GetNoColorButton();
        isEnable = true;
    }
    IEnumerator PauseOfGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        NoRightClickEvent.Invoke();
    }

    public IEnumerator GenerationPrimerIsTimeBarFalse()
    {
        yield return new WaitForSeconds(1);
        UpdateDataButtons();
    }

}
