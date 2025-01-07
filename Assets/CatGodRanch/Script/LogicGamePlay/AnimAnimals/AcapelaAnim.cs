using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AcapelaAnim : AnimTutBase
{
    public GameObject acapela;
    public Transform post_1;
    public Transform post_2;

  
    public GameObject coin_1;
    public GameObject coin_2;


    

    public override void Init()
    {

        StartCoroutine(HandleShowTut());

    }
    private IEnumerator HandleShowTut()
    {

        yield return acapela.transform.DOJump(acapela.transform.position, 1, 1, 0.5f).WaitForCompletion();
        coin_1.SetActive(true);
        coin_2.SetActive(true);
       
        Sequence sequence3 = DOTween.Sequence();
        sequence3.Join(coin_1.transform.DOJump(post_1.transform.position, 1, 1, 0.5f));
        sequence3.Join(coin_2.transform.DOJump(post_2.transform.position, 1, 1, 0.5f));

        yield return sequence3.WaitForCompletion();
        coin_1.SetActive(false);
        coin_2.SetActive(false);
    
        coin_1.transform.position = post_1.transform.position;
        coin_2.transform.position = post_2.transform.position;
  
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
