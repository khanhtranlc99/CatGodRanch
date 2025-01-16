using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LaybaleDic : MonoBehaviour
{
    public Image decorImg;
    public Image imgIcon;
    public TMP_Text tvName;
    public Sprite normalCard;
    public Sprite rareCard;
    public Sprite superCard;
    public Button btn;
    DictionaryBox dictionaryBox;
    AnimalsDataProperty animalsDataProperty;
    ItemDataProperty itemDataProperty;

    public void Init(AnimalsDataProperty animalData, DictionaryBox param)
    {
        dictionaryBox = param;
        imgIcon.sprite = animalData.spriteAvatar;
        animalsDataProperty = animalData;
        switch (animalData.cardRank )
        {
            case  CardRank.Normal:
                decorImg.sprite = normalCard;
                break;
            case CardRank.Rare:
                decorImg.sprite = rareCard;
                break;
            case CardRank.SuperRare:
                decorImg.sprite = superCard;
                break;
        }
        tvName.text = animalData.name;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate { HandleClickAnimals(); });
    }
    public void Init(ItemDataProperty itemData, DictionaryBox param)
    {
        dictionaryBox = param;
        imgIcon.sprite = itemData.spriteAvatar;
        itemDataProperty = itemData;
        switch (itemData.cardRank)
        {
            case CardRank.Normal:
                decorImg.sprite = normalCard;
                break;
            case CardRank.Rare:
                decorImg.sprite = rareCard;
                break;
            case CardRank.SuperRare:
                decorImg.sprite = superCard;
                break;
        }
        tvName.text = itemData.name;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate { HandleClickItem(); });
    }

    private void HandleClickAnimals()
    {
        dictionaryBox.HandleShow(animalsDataProperty);
    }
    private void HandleClickItem()
    {
        dictionaryBox.HandleShow(itemDataProperty);
    }

}
