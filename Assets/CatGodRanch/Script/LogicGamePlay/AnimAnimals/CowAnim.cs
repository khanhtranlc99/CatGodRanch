using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class CowAnim : AnimTutBase
{
    public GameObject cow;
    public GameObject waterBuffalo;
    public GameObject tiger;
    public GameObject calf;
    public Vector3 post_1;
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        post_1 = tiger.transform.position;

        StartCoroutine(HandleShowTut());

    }
    private IEnumerator HandleShowTut()
    {
        yield return tiger.transform.DOMove(waterBuffalo.transform.position, 1).WaitForCompletion();
        waterBuffalo.SetActive(false);
    
        yield return tiger.transform.DOMove(post_1, 1).WaitForCompletion();
  
        yield return cow.transform.DOJump(cow.transform.position, 1, 1, 0.5f);
       
        calf.SetActive(true);
        yield return new WaitForSeconds(1);
        calf.SetActive(false);
        waterBuffalo.SetActive(true);
        yield return new WaitForSeconds(1);
        Init();

    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
