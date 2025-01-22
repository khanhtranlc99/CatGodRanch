using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    
    public List<CardBase> lsCardBase;
    PlayerContain playerContain;
    public List<AnimalsDataProperty> lsCurrentAnimalData;
    
    public CardBase GetCardBaseByName(AnimalsName animalsName)
    {
        foreach (var animal in lsCardBase) 
        {
          if(animal.animalsDataProperty.animalsName == animalsName)
            {
                return animal;
            }
        }
        return null;
    }
    public CardBase GetRandomLsCardRank 
    {
        get
        {
            var lsRankCard = new List<CardBase>();
            foreach (var item in lsCardBase)
            {
                if (item.CanShow())
                {
                    lsRankCard.Add(item);
                }
            }
            return lsRankCard[Random.Range(0, lsRankCard.Count)];
        }
    }
   



    public void HandleRemoveCurrentAnimals(AnimalsName animalsName)
    {
        for(int i = lsCurrentAnimalData.Count - 1; i >= 0; i--)
        {
            if (lsCurrentAnimalData[i].animalsName == animalsName)
            {
                lsCurrentAnimalData.Remove(lsCurrentAnimalData[i]);
            }
        }    
   

    }    



    public AnimalsDataProperty GetCardName(AnimalsName param)
    {
       
        foreach (var item in lsCardBase)
        {
            if (item.animalsDataProperty.animalsName == param)
            {
                return item.animalsDataProperty;
            }
        }   
        return null;
    }


    public void Init(PlayerContain playerContainParam)
    {
        playerContain = playerContainParam;
        LoadFromHome();
    }
   
 

    
    private void LoadFromHome()
    {
        lsCurrentAnimalData = new List<AnimalsDataProperty>();
        var data = JsonConvert.DeserializeObject<List<AnimalsName>>(UseProfile.DataAnimalsHome);

        if (data != null && data.Count > 0)
        {
            foreach (var item in data)
            {
                lsCurrentAnimalData.Add(GetCardName(item));
            }
            for (int i = 0; i < lsCurrentAnimalData.Count; i++)
            {
                playerContain.animalController.SpwanAnimals(lsCurrentAnimalData[i].prefabAnimals);
            }
        }
        else
        {

            StartCoroutine(ShowBox());
            GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(false);
        }
        IEnumerator ShowBox()
        {
            yield return new WaitForSeconds(1);
            if(UseProfile.CurrentLevel != 1)
            {
                CardAnimalsBox.Setup().Show();
            }

        }
    }
   

    public void SaveDataHome()
    {
        if (lsCurrentAnimalData.Count > 0)
        {
            var lsName = new List<AnimalsName>();
            foreach (var item in lsCurrentAnimalData)
            {
                lsName.Add(item.animalsName);
            }
            var data = JsonConvert.SerializeObject(lsName);
            UseProfile.DataAnimalsHome = data;
        }
    }    

 
}
