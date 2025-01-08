using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class LionAnim : AnimTutBase
{
    public GameObject femaleLion;
    public GameObject lion;
    public GameObject horse;
    public Vector3 firstPost;
    public Vector3 firstCoin;
    public GameObject coin;

  

    public override void Init()
    {
        firstPost = femaleLion.transform.position;
        firstCoin = coin.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {

        yield return femaleLion.transform.DOMove(horse.transform.position, 1f).WaitForCompletion();
        horse.gameObject.SetActive(false);
        yield return femaleLion.transform.DOMove(firstPost, 1f).WaitForCompletion();

        yield return lion.transform.DOJump(lion.transform.position, 1, 1, 0.5f).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstCoin.x, firstCoin.y + 0.5f, firstCoin.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstCoin;

        yield return new WaitForSeconds(1);
        horse.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}