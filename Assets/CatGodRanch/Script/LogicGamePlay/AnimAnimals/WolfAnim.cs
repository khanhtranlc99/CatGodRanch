using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WolfAnim : AnimTutBase
{
    public GameObject wolf;
    public GameObject sheep;
    public Vector3 firstPost;
    public Vector3 firstCoin;
    public GameObject coin;

  
    public override void Init()
    {
        firstPost = wolf.transform.position;
        firstCoin = coin.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return wolf.transform.DOMove(sheep.transform.position, 1).WaitForCompletion();
        sheep.gameObject.SetActive(false);
        yield return wolf.transform.DOMove(firstPost, 1).WaitForCompletion();

        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstCoin;

        yield return new WaitForSeconds(1);
        sheep.gameObject.SetActive(true);
      

        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}
