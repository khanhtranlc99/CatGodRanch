using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CrowAnim : AnimTutBase
{
    public GameObject crow_1;
    public GameObject crow_2;
    public GameObject lamp;
    public Vector3 firstPost;

   
    public override void Init()
    {
        firstPost = crow_1.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {

        yield return crow_1.transform.DOMove(lamp.transform.position,1).WaitForCompletion();
        lamp.gameObject.SetActive(false);
        yield return crow_1.transform.DOMove(firstPost,1).WaitForCompletion();
        crow_2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        lamp.gameObject.SetActive(true);
        crow_2.gameObject.SetActive(false);

        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }

}
