using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DogAnim : AnimTutBase
{
    public GameObject wolf;
    public GameObject dog;
    public GameObject sheep;
    public GameObject coin;
    public Vector3 firstPost;
    public Vector3 firstPostWolf;



    public override void Init()
    {
        firstPost = coin.transform.position;
        firstPostWolf = wolf.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return wolf.transform.DOMove(sheep.transform.position, 1).WaitForCompletion();
        yield return dog.transform.DOJump(dog.transform.position, 1, 1, 0.5f).WaitForCompletion();
        yield return wolf.transform.DOMove(firstPostWolf, 1).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = firstPost;
        yield return new WaitForSeconds(1f);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}