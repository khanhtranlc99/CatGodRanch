using System;
using System.Collections;
using System.Collections.Generic;
using FileHelpers.Events;
using UnityEngine;
using UnityEngine.UI;
public class OpenCardBox : BaseBox
{
    #region instance
    public static OpenCardBox instance;
    public static OpenCardBox Setup(CardRank cardRank , AnimalsDataProperty animalsData, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<OpenCardBox>(PathPrefabs.OPEN_CARD_BOX));
            instance.Init();
        }

        instance.InitState(cardRank, animalsData);
        return instance;
    }
    #endregion 
    public OpenCard openCard;
    public Transform postDown;
    public Button btnOk;
    public GameObject titler;
    AnimalsDataProperty animalsDataProperty;
    public CardBar cardBar;
    public CardRank currentCardRank;
    private void Init ()
    {
        btnOk.onClick.AddListener(delegate { HandleOk(); });
    }
    public void InitState(CardRank cardRank , AnimalsDataProperty paramAnimalsData)
    {
        currentCardRank = cardRank;
        animalsDataProperty = paramAnimalsData;
        btnOk.gameObject.SetActive(false);
        titler.SetActive(false);
        cardBar.gameObject.SetActive(false);
        openCard.transform.position = postDown.position;
        openCard.InitState(cardRank, animalsDataProperty, delegate { HandleCallBackCardRank(); });
    }

    private void HandleCallBackCardRank()
    {
        titler.SetActive(true);
        cardBar.gameObject.SetActive(true);
        switch(currentCardRank)
        {
            case CardRank.Normal:
                UseProfile.PercentCardBar += 10;
                break;
             case CardRank.Rare:
                UseProfile.PercentCardBar += 15;
                break;
            case CardRank.SuperRare:
                UseProfile.PercentCardBar += 20;
                break;
        }
        
        cardBar.InitState(ShowbuttnOk);
        HomeController.Instance.animalsHomeController.SpawnAnimalRandomPost(animalsDataProperty);
        void ShowbuttnOk()
        {
            btnOk.gameObject.SetActive(true);
        }
        
     
    } 
    public void HandleOk()
    {
        GameController.Instance.musicManager.PlayClickSound();

        Close();
    }
        
}
