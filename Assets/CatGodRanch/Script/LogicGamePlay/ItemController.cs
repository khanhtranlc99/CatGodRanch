using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public List<CardBase> lsCardBase;
    public List<ItemBase> lsCurrentItem;
    public List<ItemName> lsItemNamesPostYard = new List<ItemName>() { ItemName.Nest, ItemName.Puddle, ItemName.Sand, ItemName.Grass };
    public Transform cardParent;
    public Transform postYardParent;
    public CardBase GetRandomItemCard()
    {
        var lsItem = new List<CardBase>();
        foreach (var item in lsCardBase)
        {
            if(item.CanShow())
            {
                lsItem.Add(item);
            }  
        }
        return lsItem[Random.Range(0, lsItem.Count)];
    }
    public ItemBase GetItemBase(ItemName param)
    {      
        foreach (var item in lsCurrentItem)
        {
            if(item.itemName == param)
            {
              return item;
            }
        }
        return null;
    }

    public void Init()
    {

    }

    public void SpawnItem(ItemName itemName)
    {
        var tempCard = GetItemBase(itemName);
        if(tempCard != null)
        {
            tempCard.Init();
        }
        else
        {
            var temp = new ItemDataProperty();
            foreach (var item in lsCardBase)
            {
                if (item.itemDataProperty.itemName == itemName)
                {
                    temp = item.itemDataProperty;
                }
            }
            var itemActive = SimplePool2.Spawn(temp.objCard);
            if (!lsItemNamesPostYard.Contains(itemName))
            {
                itemActive.transform.parent = cardParent;
                itemActive.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                itemActive.transform.parent = postYardParent;
            }
            itemActive.GetComponent<ItemBase>().Init();
            lsCurrentItem.Add(itemActive.GetComponent<ItemBase>());
            GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(true);
        }
   

    }

}
