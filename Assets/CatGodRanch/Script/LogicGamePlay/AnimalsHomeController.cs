using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class AnimalsHomeController : MonoBehaviour
{
    public AnimalsData animalsData
    {
        get
        {
            if(UseProfile.CurrentLevel < 8)
            {
                return firstNormalsData;
            }
            else
            {
                return animalsDataNormal;
            }
        }
    }

    public AnimalsData firstNormalsData;
    public AnimalsData animalsDataNormal;

    public Transform postUp;
    public Transform postDown;
    public Transform postLeft;
    public Transform postRight;
    public List<AnimalsDataProperty> lsCurrentAnimals;

    public AnimalsDataProperty GetCard (AnimalsName animalsName)
    {
        foreach (var item in animalsDataNormal.lsAll)
        {
            if (item.animalsName == animalsName)
            {
                return item;
            }
        }
        return null;  
    }
    public int CounCardRank(CardRank param)
    {
        int cout = 0;
        foreach(var item in lsCurrentAnimals)
        {
            if(item.cardRank == param)
            {
                cout += 1 ;
            }
        }
        return cout;
    }


    public void Init()
    {
        HandleLoad();
    }    
    public void SpawnAnimalRandomPost(AnimalsDataProperty animalsDataProperty)
    {
        float randomX = Random.Range(postLeft.position.x, postRight.position.x);
        float randomY = Random.Range(postDown.position.y, postUp.position.y);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);
        Debug.LogError(animalsDataProperty.prefabAnimals.name);
        var temp = SimplePool2.Spawn(animalsDataProperty.prefabAnimals, randomPosition, Quaternion.identity);
        temp.gameObject.GetComponent<AnimalsHome>().Init(postUp, postDown, postLeft, postRight);
        lsCurrentAnimals.Add(animalsDataProperty);
        HandleSave();
    }
    public void SpawnAnimalRandomPost(AnimalsDataProperty animalsDataProperty, bool noAds)
    {
        float randomX = Random.Range(postLeft.position.x, postRight.position.x);
        float randomY = Random.Range(postDown.position.y, postUp.position.y);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        var temp = SimplePool2.Spawn(animalsDataProperty.prefabAnimals, randomPosition, Quaternion.identity);
        temp.gameObject.GetComponent<AnimalsHome>().Init(postUp, postDown, postLeft, postRight);
 
    }

    public void HandleSave()
    {
        if(lsCurrentAnimals.Count > 0)
        {
            var lsName = new List<AnimalsName>();
            foreach(var item in lsCurrentAnimals)
            {
                lsName.Add(item.animalsName);
            }    
            var data  = JsonConvert.SerializeObject(lsName);
            UseProfile.DataAnimalsHome = data;
        }
    }

    private void HandleLoad()
    {
        lsCurrentAnimals = new List<AnimalsDataProperty>();
        var data = JsonConvert.DeserializeObject<List<AnimalsName>>(UseProfile.DataAnimalsHome);
        if(data != null && data.Count > 0)
        {
            foreach(var item in data)
            {
                lsCurrentAnimals.Add(animalsData.GetAnimalsDataProperty(item));
            }
            foreach (var item in lsCurrentAnimals)
            {
                SpawnAnimalRandomPost(item, true);
            }
        }
   
     
    }
     
}
