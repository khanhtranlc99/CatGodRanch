using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EgleAnim : AnimTutBase
{
    public GameObject egle;
    public GameObject duck;
    public Vector3 firstPost;
    public Vector3 firstCoin;
    public GameObject coin;

 

    public override void Init()
    {
        firstPost = egle.transform.position;
        firstCoin = coin.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return egle.transform.DOMove(duck.transform.position, 1).WaitForCompletion();
        duck.gameObject.SetActive(false);
        yield return egle.transform.DOMove(firstPost, 1).WaitForCompletion();

        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstCoin;

        yield return new WaitForSeconds(1);
        duck.gameObject.SetActive(true);


        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}