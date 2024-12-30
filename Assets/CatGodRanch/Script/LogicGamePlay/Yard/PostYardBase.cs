using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEditor.Progress;
public enum PostYardType
{
    Normal,
    Nest,
    Puddle,
    Sand,
    Grass
}    

public abstract class PostYardBase : MonoBehaviour
{
    public int id;
    public PostYardType postYardType;
    public List<PostYardBase> lsNearYard;
    public Transform post;
    public GameObject outLine;
    public AnimalsBase animalsBase;
    public bool wasStay = false;
   

    public void SwitchPostYard(PostYardBase paramPost, PostYardBase postYardNew)
    {
         if(lsNearYard.Contains(paramPost))
        {
            lsNearYard.Remove(paramPost);
            lsNearYard.Add(postYardNew);
        }
    }    

    public abstract void Init();
    public abstract void InitState();
    public abstract void HandleEffect();

    public void HandleCheckOutLine()
    {
        if(animalsBase != null)
        {
            if (animalsBase.lsPostRange.Count > 0)
            {
                foreach (var item in animalsBase.lsPostRange)
                {
                    item.HandleOnOutline();
                }
            }
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

    }
   
    public void HandleOnOutline()
    {
        outLine.SetActive(true);
        
    }

    public void HandleOffOutline()
    {
         outLine.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
