using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.Android.Types;
public class CardAnimalsBox : BaseBox
{
    public static CardAnimalsBox instance;
    public static CardAnimalsBox Setup( bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<CardAnimalsBox>(PathPrefabs.CARD_ANIMALS_BOX));
            instance.Init();
        }
        instance.InitState();
        return instance;
    }
    public List<Card> lsCard;
    public Button btnRetry;
    public Button btnSkip;
    public Button btnSeeThrow;
    CardController animalsData;
    public PlayerContain playerContain;
    int percent;
    public List<CardBase> lsCurrentAnimalsData;
    public TMP_Text tmpCoin;
    private void Init()
    {
        playerContain = GamePlayController.Instance.playerContain;
        animalsData = playerContain.cardController;

        btnSeeThrow.onClick.AddListener(delegate { HandleSeeThrowBtn(); });
        btnRetry.onClick.AddListener(btnRoll);
        btnSkip.onClick.AddListener(HandleSkip);
    }
    private void InitState()
    {
        Roll();
        tmpCoin.text = playerContain.coinController.coin + "<sprite name=\"Coin\">";
    }
    private void Roll()
    {
    
            lsCurrentAnimalsData = new List<CardBase>();

            while (lsCurrentAnimalsData.Count < 3)
            {
                var rand = UnityEngine.Random.Range(0, 100);
                var temp = animalsData.GetRandomLsCardRank;
                if (!lsCurrentAnimalsData.Contains(temp))
                {
                    lsCurrentAnimalsData.Add(temp);
                }

            }


            for (int i = 0; i < lsCurrentAnimalsData.Count; i++)
            {
                lsCard[i].Init(lsCurrentAnimalsData[i]);
            }
        
           
    }
    private void btnRoll()
    {
        if (GamePlayController.Instance.playerContain.coinController.coin >= 2)
        {
            playerContain.coinController.HandlePlusCoin(-2);
            tmpCoin.text = playerContain.coinController.coin + "<sprite name=\"Coin\">";
            Roll();
        }
    }
    public void HandleOn()
    {
      
        mainPanel.gameObject.SetActive(true);
    }
    public void HandleSkip()
    {
        GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(true);
        Close();
    }
    private void HandleSeeThrowBtn()
    {
        mainPanel.gameObject.SetActive(false);
        GamePlayController.Instance.gameScene.seeThrowBtn.gameObject.SetActive(true);
    }

}
