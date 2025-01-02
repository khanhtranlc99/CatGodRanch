using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class PostYardController : MonoBehaviour
{
    public static PostYardController Instance;
    public List<PostYardBase> lsPostYardBases;
    public  PostYardBase GetPostYardBase(int id)
    {
        for (int i = 0; i < lsPostYardBases.Count; i++)
        {
            if(lsPostYardBases[i].id == id)
            {
                return lsPostYardBases[i];
            }
        }
        return null;
    }

    public PostYardBase GetRandomPostYardNormal
    {
        get
        {
            var lsTemp = new List<PostYardBase>();
            foreach (var item in lsPostYardBases)
            {
                if (item.postYardType == PostYardType.Normal)
                {
                    lsTemp.Add(item);
                
                }
            }
            return lsTemp[Random.Range(0, lsTemp.Count)];
           
        }
    }


    public PostYardBase GetRandomEmptyPost
    {
        get
        {
            var boolNull = false;
            var lsTemp = new List<PostYardBase>();
           foreach (var item in lsPostYardBases)
            {
                if(item.animalsBase == null)
                {
                    lsTemp.Add(item);
                    boolNull = true;
                }
            }
           if(boolNull)
            {
                return lsTemp[Random.RandomRange(0, lsTemp.Count)];
            }
           else
            {
                return null;
            }
        }    
    }    

    private void OnDrawGizmos()
    {
        Instance = this;
    }

    public void Init()
    {

    }    
    public void HandleOffOutLine()
    {
        foreach (var item in lsPostYardBases)
        {
            item.HandleOffOutline();
        }
    }
   // [Button]
    private void SetId()
    {
        for(int i = 0; i < lsPostYardBases.Count; i ++)
        {
            lsPostYardBases[i].id = i;
        }
    }
  //  [Button]
    private void Save()
    {
        for (int i = 0; i < lsPostYardBases.Count; i++)
        {
            lsPostYardBases[i].GetComponent<PostYardNormal>().HandleSave();
        }
    }
   // [Button]
    private void Load()
    {
        for (int i = 0; i < lsPostYardBases.Count; i++)
        {
            lsPostYardBases[i].GetComponent<PostYardNormal>().HandleLoad();
        }
    }
}
