using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GooseAnim : AnimTutBase
{
    public GameObject fox;
    public GameObject goose;
    public GameObject chicken;
    public GameObject coin;
    public Vector3 firstPost;
    public Vector3 firstPostFox;

 
    public override void Init()
    {
        firstPost = coin.transform.position;
        firstPostFox = fox.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return fox.transform.DOMove(chicken.transform.position,1).WaitForCompletion();
        yield return goose.transform.DOJump(goose.transform.position, 1, 1, 0.5f).WaitForCompletion();
        yield return fox.transform.DOMove(firstPostFox, 1).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return  coin.transform.DOMove(new Vector3(firstPost.x, firstPost.y + 0.5f, firstPost.z), 1).WaitForCompletion();
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
