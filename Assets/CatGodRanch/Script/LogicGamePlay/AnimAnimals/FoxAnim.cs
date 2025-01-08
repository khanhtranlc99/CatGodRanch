using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FoxAnim : AnimTutBase
{
    public GameObject fox;
    public GameObject chicken;
    public Vector3 firstPost;
    public Vector3 firstCoin;
    public GameObject coin;



    public override void Init()
    {
        firstPost = fox.transform.position;
        firstCoin = coin.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return fox.transform.DOMove(chicken.transform.position, 1).WaitForCompletion();
        chicken.gameObject.SetActive(false);
        yield return fox.transform.DOMove(firstPost, 1).WaitForCompletion();

        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstCoin;

        yield return new WaitForSeconds(1);
        chicken.gameObject.SetActive(true);


        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}
