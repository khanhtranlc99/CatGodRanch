using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class AnimTutBase : MonoBehaviour
{
    public abstract void Init();
}
[System.Serializable]
public class TutData
{
    public GameObject obj;
    public GameObject coin;
    public Vector3 postCoinFirst; 
}