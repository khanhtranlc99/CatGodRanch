using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class CardRandomHome : MonoBehaviour
{
    public CardRank cardRank;
    public int id;
    public Image icon;
    public Text tvName;
    public GameObject decor;
    public int Price
    {
        get
        {
            int price = 0;
            switch (cardRank)
            {
                case CardRank.Normal:
                    price = 500 + 150 *HomeController.Instance.animalsHomeController.CounCardRank(CardRank.Normal) ;
                
                    break;

                case CardRank.Rare:
                    price = 800 + 180 * HomeController.Instance.animalsHomeController.CounCardRank(CardRank.Rare) ;
                    break;
                case CardRank.SuperRare:
                    price = 1200 + 200 *HomeController.Instance.animalsHomeController.CounCardRank(CardRank.SuperRare);
                    break;
            }
            return price;
        }
    }
    public void Init ()
    {
        switch(cardRank)
        {
            case CardRank.Normal:

                break;

            case CardRank.Rare:
                 if(UseProfile.CurrentLevel < 5)
                {
                    tvName.text = "Unlock at level 5";
                }
                break;
            case CardRank.SuperRare:
                if (UseProfile.CurrentLevel < 10)
                {
                    tvName.text = "Unlock at level 10";
                }
                break;
        }
    }
 
    public void HandleScaleIn()
    {
        this.transform.localScale =  new Vector3(1.1f, 1.1f, 1.1f) ;
        switch (cardRank)
        {
            case CardRank.Normal:
                RandomCardBox.instance.btnRandom.gameObject.SetActive(true);
                break;

            case CardRank.Rare:
                if (UseProfile.CurrentLevel < 5)
                {
                    RandomCardBox.instance.btnRandom.gameObject.SetActive(false);
                }
                else
                {
                    RandomCardBox.instance.btnRandom.gameObject.SetActive(true);
                }
                break;
            case CardRank.SuperRare:
                if (UseProfile.CurrentLevel < 10)
                {
                    RandomCardBox.instance.btnRandom.gameObject.SetActive(false);
                }
                else
                {
                    RandomCardBox.instance.btnRandom.gameObject.SetActive(true);
                }
                break;

        }
    }
    public void HandleScaleOut()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
      
    }

    public void HandleRoll(AnimalsDataProperty animalsDataProperty , Action CallBack)
    {
        this.transform.DORotate(new Vector3(0,90,0), 0.5f).OnComplete(delegate
        {
            icon.gameObject.SetActive(true);
            decor.gameObject.SetActive(false);
            icon.sprite = animalsDataProperty.spriteAvatar;
            tvName.text = animalsDataProperty.name;
            this.transform.DORotate(new Vector3(0, 360, 0), 0.5f).OnComplete(delegate
            {
                CallBack?.Invoke();

            });
        });
  
    }    
    public void HanleReset()
    {
        icon.gameObject.SetActive(false);
        decor.gameObject.SetActive(true);
        tvName.text = "";
    }

}
