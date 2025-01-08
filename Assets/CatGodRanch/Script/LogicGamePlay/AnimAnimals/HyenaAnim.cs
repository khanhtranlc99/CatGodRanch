using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HyenaAnim : AnimTutBase
{
    public GameObject tiger;
    public GameObject hyena;
    public GameObject waterBuffalo;
    public GameObject coin;
    public Vector3 firstPost;
    public Vector3 tigerPost;
    public Vector3 hyenaPost;

  
    public override void Init()
    {
        firstPost = coin.transform.position;
        tigerPost = tiger.transform.position;
        hyenaPost = hyena.transform.position;

        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return tiger.transform.DOMove(waterBuffalo.transform.position, 0.7f).WaitForCompletion();
        yield return hyena.transform.DOMove(tiger.transform.position,0.7f).WaitForCompletion();
        tiger.SetActive(false);
        yield return hyena.transform.DOMove(hyenaPost, 1).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;
        tiger.transform.position = tigerPost;
        tiger.SetActive(true);
        yield return new WaitForSeconds(1f);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}