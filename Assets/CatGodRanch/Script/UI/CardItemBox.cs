using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardItemBox : BaseBox
{
    public static CardItemBox _instance;
    public static CardItemBox Setup(PlayerContain playerContainParam, ItemController param, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (_instance == null)
        {
            _instance = Instantiate(Resources.Load<CardItemBox>(PathPrefabs.CARD_ITEM_BOX));
            _instance.Init(param, playerContainParam);
        }
        _instance.InitState();
        return _instance;
    }

    public List<ItemCardUI> lsCard;
    public Button btnRetry;
    public Button btnSkip;
    public Button btnSeeThrow;
    ItemController itemData;
    public PlayerContain playerContain;
    int percent;
    public List<CardBase> lsCurrentAnimalsData;
    public TMP_Text tmpCoin;

    private void Init(ItemController param, PlayerContain playerContainParam)
    {
        itemData = param;
        playerContain = playerContainParam;
        btnSeeThrow.onClick.AddListener(Close);
        btnRetry.onClick.AddListener(btnRoll);
        btnSkip.onClick.AddListener(Close);
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
          var temp = itemData.GetRandomItemCard();
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
        if (GamePlayController.Instance.playerContain.coinController.coin >= 5)
        {
            playerContain.coinController.HandlePlusCoin(-5);
            tmpCoin.text = playerContain.coinController.coin + "<sprite name=\"Coin\">";
            Roll();
        }
    }
}
