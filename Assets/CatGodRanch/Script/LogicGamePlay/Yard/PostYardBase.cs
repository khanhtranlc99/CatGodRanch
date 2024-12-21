using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
   

    public abstract void Init();
    public abstract void InitState();
    public abstract void HandleEffect();

    
}
