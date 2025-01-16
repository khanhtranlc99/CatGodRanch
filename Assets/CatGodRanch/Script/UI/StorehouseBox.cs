using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorehouseBox : BaseBox
{

    #region instance
    public static StorehouseBox instance;
    public static StorehouseBox Setup( Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<StorehouseBox>(PathPrefabs.STORE_HOUSE_BOX));
            instance.Init();
        }

        instance.InitState();
        return instance;
    }
    #endregion

    public Transform postContent;
    public Button btnReturn;
    public BtnCardInGame btnCardInGame;
    public List<BtnCardInGame> lsBtnCard;

    public void Init()
    {
        btnReturn.onClick.AddListener(Close);
    }
    public void InitState()
    {
        if(lsBtnCard.Count > 0)
        {
            foreach(var item in lsBtnCard)
            {
                SimplePool2.Despawn(item.gameObject);
            }
            lsBtnCard.Clear();
        }   
        foreach(var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            var temp = SimplePool2.Spawn(btnCardInGame);
            temp.transform.SetParent(postContent,false);
            temp.Init(item, this);
            lsBtnCard.Add(temp);
        }
    }

    public void HandleOffAll()
    {
        foreach (var item in lsBtnCard)
        {
            item.HandleOffRemove();
        }
    }
}

