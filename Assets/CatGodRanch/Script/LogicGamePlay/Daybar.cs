using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Daybar : MonoBehaviour
{
    public Image icon;
    public GameObject bg;
    public Sprite iconWork;
    public Sprite iconPay;
    public TMP_Text tvNumb;
    public void Init(DataDay data)
    {
        switch(data.dayType)
        {
            case DayType.Work:
                icon.sprite = iconWork;
                tvNumb.gameObject.SetActive(false);
                break;
            case DayType.Pay:
                icon.sprite = iconPay;
                tvNumb.gameObject.SetActive(true);
                tvNumb.text = "" + data.numb;
                break;
        }
    }    

    public void SetActiveBg()
    {
        bg.gameObject.SetActive(true);
    }
    public void SetDeActiveBg()
    {
        bg.gameObject.SetActive(false);
    }
}
