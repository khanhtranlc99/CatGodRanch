using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Purchasing;

public class BtnCardInGame : MonoBehaviour
{
    public Image icon;
    public Image decorCard;
    public TMP_Text tmpCoin;
    public GameObject objBlindCard;
    public Button btnClick;
    public Sprite normalCard;
    public Sprite rareCard;
    public Sprite superCard;
    int coinRemove;
    StorehouseBox storehouseBox;
    public Button btnRemove;
    AnimalsBase animalsBase1;
    public void Init(AnimalsBase animalsBase, StorehouseBox param)
    {
        animalsBase1 = animalsBase;
        storehouseBox = param;
        icon.sprite = animalsBase.spriteRender.sprite;
        switch (animalsBase.animalsRank)
        {
            case CardRank.Normal:
                decorCard.sprite = normalCard;
                coinRemove = 5;
                break;
            case CardRank.Rare:
                decorCard.sprite = rareCard;
                coinRemove = 8;
                break;
            case CardRank.SuperRare:
                decorCard.sprite = superCard;
                coinRemove = 10;
                break;
        }
        tmpCoin.text = "Remove -" + coinRemove + "<sprite name=\"Coin\">";
        HandleOffRemove();
        btnClick.onClick.RemoveAllListeners();
        btnClick.onClick.AddListener(HandleOnRemove);
        btnRemove.onClick.RemoveAllListeners();
        btnRemove.onClick.AddListener(HandleRemove);
    }
    private void HandleRemove()
    {
        
        GamePlayController.Instance.playerContain.coinController.HandlePlusCoin(-coinRemove);
        animalsBase1.HandleActionDie();
        GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(animalsBase1);
        SimplePool2.Despawn(this.gameObject);
    }    
    public void HandleOnRemove()
    {
        
        storehouseBox.HandleOffAll();
        objBlindCard.SetActive(true);
    }
    public void HandleOffRemove()
    {
        objBlindCard.SetActive(false);
    }
}
