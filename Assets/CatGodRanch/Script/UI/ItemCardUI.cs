using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemCardUI : MonoBehaviour
{
    public Image bgCard;
    public Image iconAnimals;
    public Text tvName;
    public TMP_Text tvContent;
    public Text tvPrice;
    public Button btnCard;
    ItemDataProperty itemsData;
    public void Init(CardBase param)
    {
        itemsData = param.itemDataProperty;
        iconAnimals.sprite = itemsData.spriteAvatar;
        tvName.text = itemsData.name;
        tvContent.text = itemsData.content;
 
        tvPrice.text = "Buy: " + itemsData.price;
        btnCard.onClick.RemoveAllListeners();
        btnCard.onClick.AddListener(OnClick);
        switch (param.cardRank)
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
    private void OnClick()
    {
        GamePlayController.Instance.playerContain.itemController.SpawnItem(itemsData.itemName);
        CardItemBox._instance.Close();
    }
}
