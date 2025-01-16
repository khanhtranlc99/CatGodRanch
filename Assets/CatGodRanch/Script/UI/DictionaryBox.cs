using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DictionaryBox : BaseBox
{

    #region instance
    public static DictionaryBox instance;
    public static DictionaryBox Setup( bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<DictionaryBox>(PathPrefabs.DICTIONARY_BOX));
            instance.Init();
        }

        instance.InitState();
        return instance;
    }
    #endregion
    public LaybaleDic laybaleDic;
    public Transform content;

    public ItemData itemData;
    public AnimalsData animalsData;
    public Image icon;
    public Image cardDecor;
    public Sprite normalImg;
    public Sprite rareImg;
    public Sprite superImg;
    public TMP_Text tmpContent;

    public List<LaybaleDic> listDic;

    public Button btnBird;
    public Button btnHoofed;
    public Button btnCarnivore;
    public Button btnClose;

    public Button btnAnimals;
    public Button btnItem;

    public void Init()
    {
        listDic = new List<LaybaleDic>();
        HandleAnimalsData();
        btnClose.onClick.AddListener(Close);
        btnBird.onClick.AddListener(HandleBirdAnimalsData);
        btnHoofed.onClick.AddListener(HandleHoofedAnimalsData);
        btnCarnivore.onClick.AddListener(HandleCarnivoreAnimalsData);
        btnAnimals.onClick.AddListener(delegate { HandleBtnAnimals();  });
        btnItem.onClick.AddListener(delegate { HandleBtnItem(); });
        btnAnimals.gameObject.SetActive(false);
        btnItem.gameObject.SetActive(true);
    }
    public void InitState()
    {

    }
    private void HandleAnimalsData()
    {
        if(listDic.Count > 0)
        {
            foreach(var item in listDic)
            {
                SimplePool2.Despawn(item.gameObject);
            }
        }
        var tempList = new List<AnimalsDataProperty>();
        foreach (var item in animalsData.lsAnimalsData)
        {
            foreach (var itemTemp in item.animalsDataProperty)
            {
                tempList.Add(itemTemp);
            }
        }
        foreach(var item in tempList)
        {
            var temp = SimplePool2.Spawn(laybaleDic);
            temp.transform.SetParent(content, false);
            temp.Init(item, this);
            listDic.Add(temp);
        }
        HandleShow(tempList[0]);
    }
    private void HandleBirdAnimalsData()
    {
        if (listDic.Count > 0)
        {
            foreach (var item in listDic)
            {
                SimplePool2.Despawn(item.gameObject);
            }
        }
        var tempList = new List<AnimalsDataProperty>();
        foreach (var item in animalsData.lsDataBird)
        {
            tempList.Add(item);
        }
        foreach (var item in tempList)
        {
            var temp = SimplePool2.Spawn(laybaleDic);
            temp.transform.SetParent(content, false);
            temp.Init(item, this);
            listDic.Add(temp);
        }
        HandleShow(tempList[0]);
    }
    private void HandleHoofedAnimalsData()
    {
        if (listDic.Count > 0)
        {
            foreach (var item in listDic)
            {
                SimplePool2.Despawn(item.gameObject);
            }
        }
        var tempList = new List<AnimalsDataProperty>();
        foreach (var item in animalsData.lsDataHoofed)
        {
            tempList.Add(item);
        }
        foreach (var item in tempList)
        {
            var temp = SimplePool2.Spawn(laybaleDic);
            temp.transform.SetParent(content, false);
            temp.Init(item, this);
            listDic.Add(temp);
        }
        HandleShow(tempList[0]);
    }
    private void HandleCarnivoreAnimalsData()
    {
        if (listDic.Count > 0)
        {
            foreach (var item in listDic)
            {
                SimplePool2.Despawn(item.gameObject);
            }
        }
        var tempList = new List<AnimalsDataProperty>();
        foreach (var item in animalsData.lsDataCarnivore)
        {
            tempList.Add(item);
        }
        foreach (var item in tempList)
        {
            var temp = SimplePool2.Spawn(laybaleDic);
            temp.transform.SetParent(content, false);
            temp.Init(item, this);
            listDic.Add(temp);
        }
        HandleShow(tempList[0]);
    }

    private void HandleItemsData()
    {
        if (listDic.Count > 0)
        {
            foreach (var item in listDic)
            {
                SimplePool2.Despawn(item.gameObject);
            }
        }
        var tempList = new List<ItemDataProperty>();
        foreach (var item in itemData.lsItemProperties)
        {
            tempList.Add(item);
        }
        foreach (var item in tempList)
        {
            var temp = SimplePool2.Spawn(laybaleDic);
            temp.transform.SetParent(content, false);
            temp.Init(item, this);
            listDic.Add(temp);

        }
        HandleShow(tempList[0]);
    }
    public void HandleShow(AnimalsDataProperty animalsDataProperty)
    {
        switch(animalsDataProperty.cardRank)
        {
            case CardRank.Normal:
                cardDecor.sprite = normalImg;
                break;
            case CardRank.Rare:
                cardDecor.sprite = rareImg;
                break;
            case CardRank.SuperRare:
                cardDecor.sprite = superImg;
                break;
        }
        icon.sprite = animalsDataProperty.spriteAvatar;
        tmpContent.text = animalsDataProperty.content;
    }
    public void HandleShow(ItemDataProperty animalsDataProperty)
    {
        switch (animalsDataProperty.cardRank)
        {
            case CardRank.Normal:
                cardDecor.sprite = normalImg;
                break;
            case CardRank.Rare:
                cardDecor.sprite = rareImg;
                break;
            case CardRank.SuperRare:
                cardDecor.sprite = superImg;
                break;
        }
        icon.sprite = animalsDataProperty.spriteAvatar;
        tmpContent.text = animalsDataProperty.content;
    }


    private void HandleBtnAnimals()
    {
        btnBird.gameObject.SetActive(true);
        btnHoofed.gameObject.SetActive(true);
        btnCarnivore.gameObject.SetActive(true);
        btnItem.gameObject.SetActive(true);
        btnAnimals.gameObject.SetActive(false);
        HandleAnimalsData();
    }
    private void HandleBtnItem()
    {
        btnBird.gameObject.SetActive(false);
        btnHoofed.gameObject.SetActive(false);
        btnCarnivore.gameObject.SetActive(false);
        btnItem.gameObject.SetActive(false);
        btnAnimals.gameObject.SetActive(true);
        HandleItemsData();
    }

}
