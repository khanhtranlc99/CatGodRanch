using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Datas/ItemData", fileName = "ItemData.asset")]
public class ItemData : ScriptableObject
{
    public List<ItemProperty> lsItemDatas;
}
[System.Serializable] 
public class ItemProperty
{
    public CardRank cardRank;
    public List<ItemDataProperty> itemDataPropertySand;

}

[System.Serializable]
public class ItemDataProperty
{
    public ItemName itemName;
    public string name;
    public string content;
    public Sprite spriteAvatar;
    public int price;
    public GameObject objCard;

}
