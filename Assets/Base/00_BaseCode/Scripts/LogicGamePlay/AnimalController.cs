using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private PlayerContain playerContain;
    [SerializeField] private List<AnimalsBase> lsPrefabAnimals;
    private AnimalsBase GetAnimalsBase(AnimalsName animalsName)
    {
        foreach(var item in lsPrefabAnimals)
        {
            if(item.animalsName == animalsName)
            {
                return item;
            }    
        }
        return null;
    }    

    public void Init()
    {

    }
}
