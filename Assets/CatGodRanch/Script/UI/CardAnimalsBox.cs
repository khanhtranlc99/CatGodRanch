using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CardAnimalsBox : BaseBox
{
    public static CardAnimalsBox instance;
    public static CardAnimalsBox Setup(PlayerContain playerContainParam, CardController param, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<CardAnimalsBox>(PathPrefabs.CARD_ANIMALS_BOX));
            instance.Init(param, playerContainParam);
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
    private void Init(CardController param, PlayerContain playerContainParam)
    {
        animalsData = param;
        playerContain = playerContainParam;
        btnSeeThrow.onClick.AddListener(Close);
        btnRetry.onClick.AddListener(Roll);
        btnSkip.onClick.AddListener(Roll);
    }
    private void InitState()
    {
        Roll();
  
    }
    private void Roll()
    {
        percent = (playerContain.dayController.currentDay *100) / playerContain.dayController.endDay;
  
        if(percent <= 35)
        {
            lsCurrentAnimalsData = new List<CardBase>();
          
            while (lsCurrentAnimalsData.Count < 3)
            {
                var rand = UnityEngine.Random.Range(0, 100);
                if (rand < 70)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Normal);
                    if(!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }     
                }
                if (rand > 70)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Rare);
                    if(!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }            
                }
            }      
        }
        if (percent > 35 && percent <= 65)
        {
            lsCurrentAnimalsData = new List<CardBase>();
          
            while (lsCurrentAnimalsData.Count < 3)
            {
                var rand = UnityEngine.Random.Range(0, 100);
                if (rand <= 35)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Normal);
                    if(!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }          
                }
                if (rand > 35 && rand <= 90)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Rare);
                    if (!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }           
                }
                if (rand > 90 && rand <= 100)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.SuperRare);                    
                    if (!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }
                }
            }
          
        }
        if (percent > 65)
        {
            lsCurrentAnimalsData = new List<CardBase>();
         
            while (lsCurrentAnimalsData.Count < 3)
            {
                var rand = UnityEngine.Random.Range(0, 100);
                if (rand <= 25)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Normal);
                    if (!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }   
                }
                if (rand > 25 && rand <= 85)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.Rare);
                    if (!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }      
                }
                if (rand > 85 && rand <= 100)
                {
                    var temp = animalsData.GetRandomLsCardRank(CardRank.SuperRare);
                    if (!lsCurrentAnimalsData.Contains(temp))
                    {
                        lsCurrentAnimalsData.Add(temp);
                    }      
                }
            }     
        }
        for(int i = 0; i < lsCurrentAnimalsData.Count; i ++)
        {
            lsCard[i].Init(lsCurrentAnimalsData[i]);
        }          
    }

}
