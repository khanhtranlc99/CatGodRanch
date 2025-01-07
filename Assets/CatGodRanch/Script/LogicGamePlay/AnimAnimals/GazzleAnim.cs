using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GazzleAnim : AnimTutBase
{
    public GameObject lamb;
    public GameObject gazelle;
    public GameObject post_1;
    public GameObject post_2;
    public GameObject coin;

   
    public override void Init()
    {
        lamb.transform.position = post_1.transform.position;
        gazelle.transform.position = post_2.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return gazelle.transform.DOMove(post_1.transform.position, 1).WaitForCompletion();
        yield return lamb.transform.DOMove(post_2.transform.position, 1).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(post_1.transform.position.x, post_1.transform.position.y + 0.5f, post_2.transform.position.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = post_1.transform.position;
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}