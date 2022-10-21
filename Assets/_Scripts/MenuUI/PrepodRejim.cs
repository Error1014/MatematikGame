using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepodRejim : MonoBehaviour
{
    public void ActivPrepodRejim()
    {
        SceneManager.LoadScene("SceneTeacher");
    }
    public void DeActivPrepodRejim()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScenerooms()
    {
        SceneManager.LoadScene("Rooms");
    }
}
