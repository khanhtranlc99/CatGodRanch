using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleInOut : MonoBehaviour
{
    public Vector3 scaleIn;
    public Vector3 scaleOut;
    public float speed;
    public float delayStart;
  
    void OnEnable()
    {
        if(delayStart != 0)
        {
            StartCoroutine(enumerator());
        }
        else
        {
            HandleScaleInOut();
        }
        
    }
    IEnumerator enumerator ()
    {
        yield return new WaitForSeconds(delayStart);
        HandleScaleInOut();
    }
    private void HandleScaleInOut()
    {
        this.transform.DOScale(scaleIn, speed).OnComplete(delegate {

            this.transform.DOScale(scaleOut, speed).OnComplete(delegate {
                HandleScaleInOut();
            });
        });
    }
    private void OnDestroy()
    {
        this.transform.DOKill();
    }
    private void OnDisable()
    {
        this.transform.DOKill();
    }
  
  
}
