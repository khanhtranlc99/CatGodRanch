using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI.Extensions;
using UnityEngine.Purchasing;

public class RandomCardBox : BaseBox
{
    #region instance
    public static RandomCardBox instance;
    public static RandomCardBox Setup(AnimalsData animalsData, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<RandomCardBox>(PathPrefabs.RANDOM_CARD_BOX));
            instance.Init(animalsData);
        }

        instance.InitState();
        return instance;
    }
    #endregion
    public List<CardRandomHome> lsCardRandomHome;
    public Button btnRandom;
  
    public int coutMonney;
    public TMP_Text tvPrice;
    public HorizontalScrollSnap horizontalScrollSnap;
    public AnimalsData animalsData;
    public List<GameObject> lsObjChooseCard;
    public List<GameObject> lsObjGot;
    AnimalsDataProperty animalsDataProperty;
    public CardBar cardBar;
    public Button btnClose;
    public CoinBar coinBar;
    public int price;
    public AudioClip sfx;
    private void Init (AnimalsData animalsDataParam)
    {
        animalsData = animalsDataParam;
        btnRandom.onClick.AddListener(HandleRollClick);
        btnClose.onClick.AddListener(delegate { GameController.Instance.musicManager.PlayClickSound(); Close(); });
        coinBar.Init();
        foreach (var item in lsCardRandomHome)
        {
            item.Init();
        }
    }
    private void InitState()
    {
        cardBar.Init();
        animalsDataProperty = null;

        GameController.Instance.musicManager.PlayOneShot(sfx);
        ChangePrice();
        if (UseProfile.CurrentLevel == 10)
        {
            Invoke(nameof(TestUpdate2), 0.5f);
            return ;
        }
        if (UseProfile.CurrentLevel == 5)
        {
            Invoke(nameof(TestUpdate), 0.5f);
            return;
        }
        if (UseProfile.CurrentLevel == 1)
        {
            btnClose.gameObject.SetActive(false);
        }
       
    
    }
    
    private void Update()
    {
       foreach(var item in lsCardRandomHome)
        {
            item.HandleScaleOut();
        }
        lsCardRandomHome[horizontalScrollSnap.CurrentPage].HandleScaleIn();
    }
    private void TestUpdate()
    {
        horizontalScrollSnap.ChangePage(1);
    }
    private void TestUpdate2()
    {
        horizontalScrollSnap.ChangePage(2);
    }

    private void HandleRollClick()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (UseProfile.Coin >= price)
        {
            UseProfile.Coin -= price;
            var temp = CardRank.Normal;
            switch (horizontalScrollSnap.CurrentPage)
            {
                case 0:
                    animalsDataProperty = animalsData.GetRandomLsCardRank(CardRank.Normal);
                    temp = CardRank.Normal;
                    break;
                case 1:
                    animalsDataProperty = animalsData.GetRandomLsCardRank(CardRank.Rare);
                    temp = CardRank.Rare;
                    break;
                case 2:
                    animalsDataProperty = animalsData.GetRandomLsCardRank(CardRank.SuperRare);
                    temp = CardRank.SuperRare;
                    break;
            }
            Close();
            ChangePrice();
            OpenCardBox.Setup(temp, animalsDataProperty).Show();
        }
        else
        {
            ShopBox.Setup().Show();
        }         
    }
    public void ChangePrice()
    {
        price = lsCardRandomHome[horizontalScrollSnap.CurrentPage].Price;
        tvPrice.text = "Buy x1" + "\n" + price + "<sprite name=\"Coin\">";
      
    }

   

}
