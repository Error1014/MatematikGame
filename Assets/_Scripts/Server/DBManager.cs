using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Send());
    }

    private IEnumerator Send()
    {
        WWWForm form = new WWWForm();
        form.AddField("WelcomeMsg", "Дороу");
        WWW www = new WWW("http://home/n/n91080c4/math_game/public_htmlindex2.php", form);
        yield return www;
        if (www.error!=null)
        { 
            Debug.Log("Ошибка: "+www.error);
            yield break;
        }
        Debug.Log("Сервер ответил: "+www.text);
    }
}
