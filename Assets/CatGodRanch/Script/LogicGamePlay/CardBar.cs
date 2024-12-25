using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CardBar : MonoBehaviour
{
    public Text tvCount;
    public Image fillAmount;
    public Image icon;

    public void Init()
    {
        var temp = (float)UseProfile.PercentCardBar / 100;
        fillAmount.fillAmount = temp;
        tvCount.text = temp*100 + "/100";
    }

    public void InitState(Action callBack)
    {
        var temp = (float)UseProfile.PercentCardBar/100;
        if(temp < 1)
        {
            fillAmount.DOFillAmount(temp, 0.75f).OnComplete(delegate { HandleScaleIcon(callBack); })  ;
        }   
        else
        {
            fillAmount.DOFillAmount(temp, 0.75f).OnComplete(delegate { HandleScaleIcon(true, callBack); });
        }
        tvCount.text = temp * 100 + "/100";
    }

    private void HandleScaleIcon(Action callBack)
    {
        icon.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).OnComplete(delegate
        {
            icon.transform.DOScale(new Vector3(1, 1, 1), 0.5f).OnComplete(delegate
            {

                callBack?.Invoke();
            });

        });
    }
    private void HandleScaleIcon(bool param, Action callBack)
    {
        icon.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).OnComplete(delegate
        {
            icon.transform.DOScale(new Vector3(1, 1, 1), 0.5f).OnComplete(delegate
            {
                fillAmount.fillAmount = 0;
              UseProfile.PercentCardBar = 0;
              var animalsDataProperty = HomeController.Instance.animalsHomeController.animalsData.GetRandomLsCardRank(CardRank.Normal);
              OpenCardBox.instance.InitState(CardRank.Normal, animalsDataProperty);
               
            });

        });
    }
}
