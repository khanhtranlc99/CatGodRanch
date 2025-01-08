using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TigerAnim : AnimTutBase
{
    public GameObject tiger;
    public GameObject cow;
    public GameObject waterBuffalo;
    public GameObject goat;
    public GameObject calf;
    public GameObject coin;
    public Vector3 firstPost;
    public Vector3 tigerPost;

     
    public override void Init()
    {
        firstPost = coin.transform.position;
        tigerPost = tiger.transform.position;
     

        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return tiger.transform.DOMove(cow.transform.position, 0.7f).WaitForCompletion();
        cow.SetActive(false);
        yield return tiger.transform.DOMove(tigerPost, 0.7f).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;


        yield return tiger.transform.DOMove(goat.transform.position, 0.7f).WaitForCompletion();
        goat.SetActive(false);
        yield return tiger.transform.DOMove(tigerPost, 0.7f).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;

        yield return tiger.transform.DOMove(waterBuffalo.transform.position, 0.7f).WaitForCompletion();
        waterBuffalo.SetActive(false);
        yield return tiger.transform.DOMove(tigerPost, 0.7f).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;


        yield return tiger.transform.DOMove(calf.transform.position, 0.7f).WaitForCompletion();
        calf.SetActive(false);
        yield return tiger.transform.DOMove(tigerPost, 0.7f).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;



 
        yield return new WaitForSeconds(1f);
        cow.SetActive(true);
        goat.SetActive(true);
        waterBuffalo.SetActive(true);
        calf.SetActive(true);
        yield return new WaitForSeconds(1f);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}