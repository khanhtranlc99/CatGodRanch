using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class OpenCard : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public Text tvName;
    public GameObject decor;
    public Transform postMid;

    public Sprite normalCard;
    public Sprite rareCard;
    public Sprite superCard;


    public void InitState(CardRank cardRank, AnimalsDataProperty animalsDataProperty, Action callBack)
    {
        this.transform.localScale = Vector3.zero;
        icon.gameObject.SetActive(false);
        decor.SetActive(true);
        tvName.text = "";
        switch (cardRank)
        {
            case CardRank.Normal:
                bg.sprite = normalCard;
                break;
            case CardRank.Rare:
                bg.sprite = rareCard;
                break;
            case CardRank.SuperRare:
                bg.sprite = superCard;
                break;
        }
       
        this.transform.DOKill();
        this.transform.DOScale(new Vector3(1, 1, 1), 1);

        this.transform.DOMove(postMid.transform.position, 1.5f).SetEase(Ease.InOutBack).OnComplete(delegate {
            this.transform.DORotate(new Vector3(0, 90, 0), 0.5f).SetDelay(0.5f).OnComplete(delegate
            {
                icon.gameObject.SetActive(true);
                decor.gameObject.SetActive(false);
                icon.sprite = animalsDataProperty.spriteAvatar;
                tvName.text = animalsDataProperty.name;
                this.transform.DORotate(new Vector3(0, 360, 0), 0.5f).OnComplete(delegate
                {
                    callBack?.Invoke();

                });
            });
        });
      

    }

}
