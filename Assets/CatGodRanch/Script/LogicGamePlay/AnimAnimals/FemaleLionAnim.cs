using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FemaleLionAnim : AnimTutBase
{
    public GameObject femaleLion;
    public GameObject gazzle;
    public Vector3 firstPost;
    public Vector3 firstCoin;
    public GameObject coin;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        firstPost = femaleLion.transform.position;
        firstCoin = coin.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return femaleLion.transform.DOMove(gazzle.transform.position, 1).WaitForCompletion();
        gazzle.gameObject.SetActive(false);
        yield return femaleLion.transform.DOMove(firstPost, 1).WaitForCompletion();

        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstCoin;

        yield return new WaitForSeconds(1);
        gazzle.gameObject.SetActive(true);


        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}