using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

using UnityEngine;
using DG.Tweening;
public class MagpieAnim : AnimTutBase
{
    public GameObject magpie;
    public Transform post_1;
    public Transform post_2;
    public Transform post_3;
    public Transform post_4;
    public GameObject coin_1;
    public GameObject coin_2;
    public GameObject coin_3;
    public GameObject coin_4;

    
    public override void Init()
    {
       
        StartCoroutine(HandleShowTut());

    }
    private IEnumerator HandleShowTut()
    {

        yield return magpie.transform.DOJump(magpie.transform.position, 1, 1, 0.5f).WaitForCompletion();
        coin_1.SetActive(true);
        coin_2.SetActive(true);
        coin_3.SetActive(true);
        coin_4.SetActive(true);
        Sequence sequence3 = DOTween.Sequence();
        sequence3.Join(coin_1.transform.DOJump(post_1.transform.position, 1, 1, 0.5f));
        sequence3.Join(coin_2.transform.DOJump(post_2.transform.position, 1, 1, 0.5f));
        sequence3.Join(coin_3.transform.DOJump(post_3.transform.position, 1, 1, 0.5f));
        sequence3.Join(coin_4.transform.DOJump(post_4.transform.position, 1, 1, 0.5f));
        yield return sequence3.WaitForCompletion();
        coin_1.SetActive(false);
        coin_2.SetActive(false);
        coin_3.SetActive(false);
        coin_4.SetActive(false);
         coin_1.transform.position = magpie.transform.position;
         coin_2.transform.position = magpie.transform.position;
        coin_3.transform.position = magpie.transform.position;
        coin_4.transform.position = magpie.transform.position;
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
