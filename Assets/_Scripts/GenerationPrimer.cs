using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class GenerationPrimer : MonoBehaviour,IPunObservable
{
    [SerializeField] private Text TextPrimer;
    [SerializeField] private Button[] VariantButtons;
    public SettingData settingData;
    public static int RightOtv = 0;
    private List<string> operation = new List<string>();
    private string path;


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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(JsonUtility.ToJson(settingData));

        }
        else
        {
            string s = (string)stream.ReceiveNext();
            File.WriteAllText(path, s);
            ReadData();
        }

    }

    void Start()
    {


        if (!settingData.isTimeBar) FindObjectOfType<TimeBar>().gameObject.SetActive(false);
        GetPrimer();

        ButtonVariant.NextPrimerEvent.AddListener(GetPrimer);
    }

    
    public void GetPrimer()
    {
        int number1 = 0;
        int number2 = 0;

        string primer = "";
        string operation = "";

        number1 = Random.Range(settingData.minNumb, settingData.maxNumb + 1);
        number2 = Random.Range(settingData.minNumb, settingData.maxNumb + 1);
        operation = GetOperation();
        primer = number1.ToString() + operation + number2.ToString();

        TextPrimer.text = primer;
        RightOtv = GetRightVariant(number1, number2, operation);
        GetVatiantOtvets(number1, number2, operation);

    }
    private string GetOperation()
    {
        operation = new List<string>();
        if (settingData.isPlus)
        {
            operation.Add("+");
        }
        if (settingData.isMinus)
        {
            operation.Add("-");
        }
        if (settingData.isUmnoj)
        {
            operation.Add("*");
        }
        if (settingData.isDelen)
        {
            operation.Add("/");
        }
        return operation[Random.Range(0, operation.Count)];
    }

    private void GetVatiantOtvets(int number1, int number2, string operation)
    {
        int numRightOtv = Random.Range(0, 4);
        HashSet<int> variants = new HashSet<int>();
        variants.Add(RightOtv);
        do
        {
            variants.Add(GetNoRightVariant(number1, number2, operation));
        } while (variants.Count<4);
        var s = variants.OrderBy(c => Random.Range(0,4)).Select(c=>c);
        variants = new HashSet<int>();
        foreach (var item in s.ToArray())
        {
            variants.Add(item);
        }
        int num = 0;
        foreach (var item in variants)
        {
            VariantButtons[num].GetComponentInChildren<Text>().text = item.ToString();
            num++;
        }
    }
    private int GetRightVariant(int number1, int number2, string operation)
    {
        if (operation == "+")
        {
            return number1 + number2;
        }
        else if (operation == "-")
        {
            return number1 - number2;
        }
        else if (operation == "*")
        {
            return number1 * number2;
        }
        else if (operation == "/")
        {
            return number1 / number2;
        }
        else return 0;
    }
    private int GetNoRightVariant(int number1, int number2, string operation)
    {
        int min = settingData.minNumb;
        int max = settingData.maxNumb+1;

        int value = 0;
        
        if (operation == "+")
        {
            value = number1+Random.Range(min ,max) + number2+Random.Range(min, max);
        }
        else if (operation == "-")
        {
            value = number1 + Random.Range(min, max) - number2 + Random.Range(min, max);
        }
        else if (operation == "*")
        {
            value = number1 + Random.Range(min, max) * number2 + Random.Range(min, max);
        }
        else if (operation == "/")
        {
            value = number1 + Random.Range(min, max) / number2 + Random.Range(min, max);
        }
        return value;
    }

}
