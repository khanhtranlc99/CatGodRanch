using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using DG.Tweening;

public abstract class AnimTutBase : MonoBehaviour
{
    public abstract void Init();
    public void OnDestroy()
    {
        StopAllCoroutines();
        DOTween.KillAll();
    }
}
[System.Serializable]
public class TutData
{
    public GameObject obj;
    public GameObject coin;
    public Vector3 postCoinFirst; 
}