using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    
    public List<CardBase> lsCardBase;
    PlayerContain playerContain;
    public CardBase GetRandomLsCardRank(CardRank param)
    {
        var lsRankCard = new List<CardBase>();
        foreach (var item in lsCardBase)
        {
            if (item.cardRank == param)
            {
                lsRankCard.Add(item);
            }
        }
       
        return lsRankCard[Random.Range(0, lsRankCard.Count)];

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
        Roll();
    }
   
 

    public List<CardBase> lsCurrentAnimalsData;
    private void Roll()
    {
      
            lsCurrentAnimalsData = new List<CardBase>();
            while (lsCurrentAnimalsData.Count < 3)
            {
                var rand = UnityEngine.Random.Range(0, 100);
                if (rand < 70)
                {
                 
                    lsCurrentAnimalsData.Add(GetRandomLsCardRank(CardRank.Normal));
                }
                if (rand > 70)
                {
               
                    lsCurrentAnimalsData.Add(GetRandomLsCardRank(CardRank.Rare));
                }
            }
     
     

        for (int i = 0; i < lsCurrentAnimalsData.Count; i++)
        {
             playerContain.animalController.SpwanAnimals(lsCurrentAnimalsData[i].animalsDataProperty.prefabAnimals);
        }



    }
}
