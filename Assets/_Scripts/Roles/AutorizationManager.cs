using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutorizationManager : MonoBehaviour
{
    private string login;
    private string password;

    [SerializeField] private InputField loginBox;
    [SerializeField] private InputField passwordBox;

    public static User user = new User();
    private string path;

    private void Start()
    {
        StartCoroutine(LoadFromServer("http://home/n/n91080c4/math_game/public_html/index2.php"));
        GetPath();
        if (File.Exists(path))
        {
            ReadData();
            loginBox.text = user.login;
            passwordBox.text = user.password;
        }
    }
    public void GetLogin()
    {
        login = loginBox.text;
        user.login = login;
    }

    public void GetPassword()
    {
        password = passwordBox.text;
        user.password = password;
    }

    public void Whod()
    {
        GetLogin();
        GetPassword();
        WriteData();

        SceneManager.LoadScene("SceneTeacher");
    }

    IEnumerator LoadFromServer(string url)
    {
        var request = new UnityWebRequest(url);

        yield return request.SendWebRequest();
        if (request.error!=null)
        {
            Debug.Log("Ошибка: "+request.error);
        }
        //Debug.Log(request.downloadHandler.text);

        request.Dispose();
    }



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
        user = JsonUtility.FromJson<User>(File.ReadAllText(path));//чтение данных
    }
    #endregion

    #region запись данных
    private void WriteData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(user));//запись данных
    }
    #endregion


}


public class User
{
    public string login;
    public string password;
}
