using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteNumbText : MonoBehaviour
{
    public int minNumb;
    public int maxNumb;
    [SerializeField] private InputField textBoxMinNumb;
    [SerializeField]  private InputField textBoxMaxNumb;

    public void GetMinNumb()
    {
        minNumb = int.Parse(textBoxMinNumb.text);
        Debug.Log(minNumb);

    }

    public void GetMaxNumb()
    {
        maxNumb = int.Parse(textBoxMaxNumb.text);
        Debug.Log(maxNumb);
    }



}
