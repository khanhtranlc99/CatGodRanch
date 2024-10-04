using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class PostYardController : MonoBehaviour
{
    public static PostYardController Instance;
    [SerializeField] private List<PostYardBase> lsPostYardBases;
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
    private void OnDrawGizmos()
    {
        Instance = this;
    }
    public void Init()
    {

    }    
    [Button]
    private void SetId()
    {
        for(int i = 0; i < lsPostYardBases.Count; i ++)
        {
            lsPostYardBases[i].id = i;
        }
    }
    [Button]
    private void Save()
    {
        for (int i = 0; i < lsPostYardBases.Count; i++)
        {
            lsPostYardBases[i].GetComponent<PostYardNormal>().HandleSave();
        }
    }
    [Button]
    private void Load()
    {
        for (int i = 0; i < lsPostYardBases.Count; i++)
        {
            lsPostYardBases[i].GetComponent<PostYardNormal>().HandleLoad();
        }
    }
}
