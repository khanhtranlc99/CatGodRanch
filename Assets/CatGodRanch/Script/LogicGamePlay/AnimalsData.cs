using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(menuName = "Datas/AnimalsData", fileName = "AnimalsData.asset")]
public class AnimalsData : ScriptableObject
{
    public List<AnimalsProperty> lsAnimalsData;
    public List<AnimalsBase> lsAnimalsBases;

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
    public Sprite spriteAvatar;
    public Sprite spriteAnimalsType;
    public int price;
    public int coinPlus;
    public GameObject prefabAnimals;
}