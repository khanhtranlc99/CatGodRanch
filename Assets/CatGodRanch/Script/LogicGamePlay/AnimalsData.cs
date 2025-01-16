using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(menuName = "Datas/AnimalsData", fileName = "AnimalsData.asset")]
public class AnimalsData : ScriptableObject
{
    public List<AnimalsProperty> lsAnimalsData;
    public List<AnimalsDataProperty> lsDataBird;
    public List<AnimalsDataProperty> lsDataHoofed;
    public List<AnimalsDataProperty> lsDataCarnivore;

    public AnimalsDataProperty GetRandomLsCardRank(CardRank param)
    {
        var lsRank = new List<AnimalsDataProperty>();
        foreach (var item in lsAnimalsData)
        {
            if(item.animalsRank == param)
            {
                lsRank = item.animalsDataProperty;
            }
        }

        var tempAnimalsDataProperty = new AnimalsDataProperty();
        tempAnimalsDataProperty = lsRank[Random.Range(0, lsRank.Count)];
        return tempAnimalsDataProperty;

    }    

    public AnimalsDataProperty GetAnimalsDataProperty(AnimalsName animalsName)
    {
        foreach (var item in lsAnimalsData)
        {
          foreach(var tem in item.animalsDataProperty)
            {
                if(tem.animalsName == animalsName)
                {
                    return tem;
                }
            }
        }
        return null;

    }

    [Button]
    private void HandleFill()
    {
       var tempList = new List<AnimalsDataProperty>();
        foreach(var item in lsAnimalsData)
        {
            foreach (var itemData in item.animalsDataProperty)
            {
                tempList.Add(itemData);
            }
        }
        foreach (var item in tempList)
        {
            if(item.animalsType == AnimalsType.Carnivore)
            {
                lsDataCarnivore.Add(item);
            }
            if (item.animalsType == AnimalsType.Hoofed)
            {
                lsDataHoofed.Add(item);
            }
            if (item.animalsType == AnimalsType.Bird)
            {
                lsDataBird.Add(item);
            }
        }


    }    

  
    
}
[System.Serializable]
public class AnimalsProperty
{
    public CardRank animalsRank;
    public List<AnimalsDataProperty> animalsDataProperty;
    
    public void FillData(List<AnimalsBase> param)
    {
        var newList = new List<AnimalsBase>();
        foreach(var item in param)
        {
            newList.Add(item);
        }

        foreach (var item in newList)
        {
             if(item.animalsRank == animalsRank)
            {
                var data = new AnimalsDataProperty() { name = item.gameObject.name, prefabAnimals = item.gameObject, spriteAvatar = item.spriteRender.sprite, animalsName = item.animalsName , spriteAnimalsType  = item.spriteAnimalsType };
                animalsDataProperty.Add(data);
            }
        }
    }    

}
[System.Serializable]
public class AnimalsDataProperty
{
    public string name;
    public string content;
    public AnimalsName animalsName;
    public CardRank cardRank;
    public AnimalsType animalsType;
    public Sprite spriteAvatar;
    public Sprite spriteAnimalsType;
    public int price;
    public int coinPlus;
    public GameObject prefabAnimals;
}