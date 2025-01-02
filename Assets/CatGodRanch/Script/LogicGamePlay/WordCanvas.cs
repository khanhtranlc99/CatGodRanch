using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WordCanvas : MonoBehaviour
{
    public Image bgCard;
    public Image iconAnimals;
    public Image iconType;
    public TMP_Text tvName;
    public TMP_Text tvContent;
    public TMP_Text tvCoin;
    public TMP_Text tvPrice;
    AnimalsDataProperty animalsDataProperty;
   
    public Button btnRemove;
    AnimalsBase animals;
    int coinRemove;
    
    // Start is called before the first frame update
    public void InitState(AnimalsBase param)
    {
        animals = param;
        animalsDataProperty = GamePlayController.Instance.playerContain.cardController.GetCardName(param.animalsName);
        iconAnimals.sprite = param.spriteRender.sprite;
        iconType.sprite = animalsDataProperty.spriteAnimalsType;
        tvName.text = param.animalsName.ToString();
        tvContent.text = animalsDataProperty.content;
        tvCoin.text = param.coinPlus.ToString();
       
        switch (param.animalsRank)
        {
            case CardRank.Normal:
                bgCard.color = Color.gray;
                coinRemove = 5;
                break;
            case CardRank.Rare:
                bgCard.color = Color.blue;
                coinRemove = 8;
                break;
            case CardRank.SuperRare:
                bgCard.color = Color.yellow;
                coinRemove = 10;
                break;

        }
        tvPrice.text = "Remove -" + coinRemove + "<sprite name=\"Coin\">";
        //playerContain.coinController.coin + "<sprite name=\"Coin\">";
        btnRemove.onClick.RemoveAllListeners();
        if (GamePlayController.Instance.playerContain.coinController.coin >= coinRemove)
        {
            btnRemove.interactable = true;
            btnRemove.onClick.AddListener(delegate { HandleOnClick(); });
        }
        else
        {
            btnRemove.interactable = false;
        }
        
    }

    private void HandleOnClick()
    {
        GamePlayController.Instance.playerContain.coinController.HandlePlusCoin( -coinRemove);
        animals.HandleActionDie();
        GamePlayController.Instance.playerContain.inputController.wordCanvasController.HandleOff();
        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
    }
}
