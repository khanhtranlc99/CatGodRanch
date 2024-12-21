using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LableMission : MonoBehaviour
{
    public Image icon;
    public TMP_Text tvName;
    public Button btnClick;
    public Image progess;
    public void Start()
    {
        btnClick.onClick.AddListener(OnBtnClick);
    }


    private void OnBtnClick()
    {
        progess.fillAmount = 1;
        tvName.text = "wasBought";
    }    
}
