using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private Image Bar;
    private float fill;
    private float speed;
    private float timeAddBar = 0.3f;
    private bool isActive = true;
    private bool isEnd = false;
    public static UnityEvent EndTimeEvnt = new UnityEvent();
    public static UnityEvent AddTimeOfBar = new UnityEvent();
    private void Start()
    {
        ButtonVariant.StartClickEvent.AddListener(RestartFill);
        ButtonVariant.StartClickEvent.AddListener(OnActiv);
        ButtonVariant.NextPrimerEvent.AddListener(isActiveTimaBar);
        ButtonVariant.NoRightClickEvent.AddListener(isEndGame);
        ButtonVariant.NoRightClickEvent.AddListener(OnActiv);
        fill = 1f;
        speed = 0.1f;
        isActive = true;
        isEnd = false;

    }

    private void Update()
    {
        if (isActive)
        {
            if (isActive) fill -= Time.deltaTime * speed;
            if (fill <= 0)
            {
                EndTimeEvnt.Invoke();
                isActive = false;
                isEnd = true;

            }
            timeAddBar = 0.3f;
        }
        else if (isEnd==false)
        {
            timeAddBar -= Time.deltaTime * speed * 5f;
            fill += Time.deltaTime * speed*3f;
            if (fill>=1||timeAddBar<=0)
            {
                AddTimeOfBar.Invoke();
            }
        }
        Bar.fillAmount = fill;

    }

    public void RestartFill()
    {
        if (isActive)
        {
            
        }
        else
        {
            fill = 1f;
        }
        
    }
    public void OnActiv()
    {
        isActive = false;
    }
    public void isActiveTimaBar()
    {
        isActive = true;
    }
    public void isEndGame()
    {
        isEnd= true;
    }
}
