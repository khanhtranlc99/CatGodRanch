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
    public Sprite normalBg;
    public Sprite rageBg;
    public Sprite superBg;
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
                bgCard.sprite = normalBg;
          
                break;
            case CardRank.Rare:
                bgCard.sprite = rageBg;
         
                break;
            case CardRank.SuperRare:
                bgCard.sprite = superBg;
                
                break;
        }

    }
    private void OnClick()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GamePlayController.Instance.playerContain.itemController.SpawnItem(itemsData.itemName);
        CardItemBox._instance.Close();
    }
}
