using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PostYardBase : MonoBehaviour
{
    public int id;
    public List<PostYardBase> lsNearYard;
    public Transform post;
    public GameObject outLine;
    public abstract void Init();
    public abstract void InitState();
    public abstract void HandleEffect();

    
}
