using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    public Image bgCard;
    public Image iconAnimals;
    public Text tvName;
    public TMP_Text tvContent;
    public TMP_Text tvNumbDaily;
    public Text tvPrice;
    public Button btnCard;
    AnimalsDataProperty animalsData;

    public void Init(CardBase dataParam)
    {
        animalsData = dataParam.animalsDataProperty;
        iconAnimals.sprite = animalsData.spriteAvatar;
        tvName.text = animalsData.name;
        tvContent.text = animalsData.content;
        tvNumbDaily.text = "" + animalsData.coinPlus;
        tvPrice.text = "Buy: " + animalsData.price;
        btnCard.onClick.RemoveAllListeners();
        btnCard.onClick.AddListener(OnClick);
        switch (dataParam.cardRank)
        {
            case CardRank.Normal:
                bgCard.color = Color.gray;
                break;
            case CardRank.Rare:
                bgCard.color = Color.blue;
                break;
            case CardRank.SuperRare:
                bgCard.color = Color.yellow;
                break;
        
        }

    }



    private void OnClick( )
    {
        GamePlayController.Instance.playerContain.animalController.SpwanAnimals(animalsData.prefabAnimals);
        CardAnimalsBox.instance.Close();
    }
}
