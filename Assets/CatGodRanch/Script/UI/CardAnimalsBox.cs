using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
    public TMP_Text tmpRoll;
    public GameObject bg;
    public Button btnBook;
    public bool isText;
    public int freeRoll;
    private void Init()
    {
        playerContain = GamePlayController.Instance.playerContain;
        animalsData = playerContain.cardController;

        btnSeeThrow.onClick.AddListener(delegate { HandleSeeThrowBtn(); });
        btnRetry.onClick.AddListener(btnRoll);
        btnSkip.onClick.AddListener(HandleSkip);
        btnBook.onClick.AddListener(HandleBook);

    }
    private void InitState()
    {
        GamePlayController.Instance.playerContain.inputController.lockInput = false;
        tmpCoin.text = playerContain.coinController.coin + "<sprite name=\"Coin\">";
        freeRoll = GamePlayController.Instance.playerContain.freeRoll.GetfreeRoll;
        tmpRoll.text = "Free " + freeRoll;
        if (!UseProfile.TutGamePlayCard_Step_1)
        {
            Invoke(nameof(RollTutorial_1), 0.2f);
            return;
        }
        else
        {
           if(!UseProfile.TutGamePlayCard_Step_2)
            {
                Invoke(nameof(RollTutorial_2), 0.2f);
               
                return;
            }
            else
            {
                btnRetry.interactable = true;
                btnSkip.interactable = true;
                btnSeeThrow.interactable = true;
                btnBook.interactable = true;
                for (int i = 0; i < lsCard.Count; i++)
                {
                    lsCard[i].HandleOffBlindPanel();
                }
                if(!UseProfile.TutGamePlayCard_Step_3)
                {
                    Invoke(nameof(RollTutorial_3), 0.2f);
                   
                    return;
                }
             
            }
          
        }
 

        Invoke(nameof(Roll), 0.2f);
    }
   



    private void  Roll()
    {
        isText = false;
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

    private void RollTutorial_1()
    {
        isText = false;
        lsCurrentAnimalsData = new List<CardBase>();
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Turkey));
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Rooster));
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Duck));
        for (int i = 0; i < lsCurrentAnimalsData.Count; i++)
        {
            lsCard[i].Init(lsCurrentAnimalsData[i]);
            lsCard[i].HandleShowBlindPanel();
        }
        var temp = lsCard[1];
        for (int i = 0; i < lsCard.Count; i++)
        {
            if (lsCard[i].animalsData.animalsName == AnimalsName.Rooster)
            {
                lsCard[i].HandleOffBlindPanel();
                temp = lsCard[i];
            }
        }
        btnRetry.interactable = false;
        btnSkip.interactable = false;
        btnSeeThrow.interactable = false;
        btnBook.interactable = false;
        temp.transform.SetAsLastSibling();
        StartCoroutine(  TutGamePlayCard_Step_1.Instance.Show(temp.gameObject.transform));

    }
    private void RollTutorial_2()
    {
        Debug.LogError("RollTutorial_2");
        isText = false;
        lsCurrentAnimalsData = new List<CardBase>();
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Pigeon));
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Turkey));
        lsCurrentAnimalsData.Add(animalsData.GetCardBaseByName(AnimalsName.Fox));
        for (int i = 0; i < lsCurrentAnimalsData.Count; i++)
        {
            lsCard[i].Init(lsCurrentAnimalsData[i]);
        }
        for (int i = 0; i < lsCurrentAnimalsData.Count; i++)
        {
            lsCard[i].Init(lsCurrentAnimalsData[i]);
            lsCard[i].HandleShowBlindPanel();
        }
        var temp = lsCard[1];
        for (int i = 0; i < lsCard.Count; i++)
        {
            if (lsCard[i].animalsData.animalsName == AnimalsName.Pigeon)
            {
                lsCard[i].HandleOffBlindPanel();
                temp = lsCard[i];
            }
        }
        StartCoroutine(TutGamePlayCard_Step_1.Instance.Show(temp.gameObject.transform));
        UseProfile.TutGamePlayCard_Step_2 = true;
    }
    private void RollTutorial_3()
    {
        isText = false;
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
        for (int i = 0; i < lsCard.Count; i++)
        {    
            lsCard[i].HandleShowBlindPanel();
        }
        StartCoroutine(TutGamePlayCard_Step_1.Instance.Show2(btnRetry.gameObject.transform));
    
        btnRetry.interactable = true;
        btnSkip.interactable = false;
        btnSeeThrow.interactable = false;
        btnBook.interactable = false;
    }



    private void btnRoll()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (freeRoll > 1)
        {
            freeRoll -= 1;
            tmpRoll.text = "Free " + freeRoll;
            Roll();
            if (freeRoll <= 1)
            {
                tmpRoll.text = "-2" + "<sprite name=\"Coin\">";
            }    
            if (!UseProfile.TutGamePlayCard_Step_3)
            {
                for (int i = 0; i < lsCard.Count; i++)
                {
                    lsCard[i].HandleOffBlindPanel();
                }
                btnRetry.interactable = true;
                btnSkip.interactable = true;
                btnSeeThrow.interactable = true;
                btnBook.interactable = true;
                UseProfile.TutGamePlayCard_Step_3 = true;
                TutGamePlayCard_Step_1.Instance.HandleOffHandle();
            }    
        }
        else
        {
            
            if (GamePlayController.Instance.playerContain.coinController.coin >= 2)
            {
                playerContain.coinController.HandlePlusCoin(-2);
                tmpCoin.text = playerContain.coinController.coin + "<sprite name=\"Coin\">";
                Roll();
            }
        } 
        
    
    }
    public void HandleOn()
    {
        bg.SetActive(true);
        mainPanel.gameObject.SetActive(true);
        GamePlayController.Instance.playerContain.inputController.lockInput = false;
        foreach (var item in lsCard)
        {
            item.HandleTutCard();
        }
    }
    public void HandleSkip()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(true);
        Close();
    }
    private void HandleSeeThrowBtn()
    {
        GameController.Instance.musicManager.PlayClickSound();
        mainPanel.gameObject.SetActive(false);
        bg.SetActive(false);
        GamePlayController.Instance.gameScene.seeThrowBtn.gameObject.SetActive(true);
        GamePlayController.Instance.playerContain.inputController.lockInput = true;
    }
    private void OnDisable()
    {
        GamePlayController.Instance.playerContain.inputController.lockInput = true;
        TutGamePlayCard_Step_1.Instance.HandleOffHandle();
    }
    private void HandleBook()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (!isText)
        {
            isText = true;
            foreach (var item in lsCard)
            {
                item.HandleOnText();
            }
        }
        else
        {
            isText = false;
            foreach (var item in lsCard)
            {
                item.HandleOffText();
            }
        }
    }    
}
