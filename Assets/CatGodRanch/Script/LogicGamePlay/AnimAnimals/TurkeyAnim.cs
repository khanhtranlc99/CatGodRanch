using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TurkeyAnim : AnimTutBase
{
    public GameObject turkey;
    public GameObject fox;
    public GameObject coin;
    Vector3 post_1;
    Vector3 post_2;
   
    public override void  Init()
    {
        post_1 = fox.transform.position;
        post_2 = coin.transform.position; 
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return fox.transform.DOMove(turkey.transform.position, 1).WaitForCompletion();
        turkey.SetActive(false);
        yield return fox.transform.DOMove(post_1, 1).WaitForCompletion();
        coin.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(post_2.x, post_2.y+0.5f, post_2.z), 1).WaitForCompletion();
        coin.transform.position = post_2;
        coin.SetActive(false);
        turkey.SetActive(true);
        Init();

    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
