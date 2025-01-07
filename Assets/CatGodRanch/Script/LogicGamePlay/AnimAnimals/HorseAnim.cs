using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class HorseAnim : AnimTutBase
{
    public GameObject horse;
    public GameObject post_1;
    public GameObject post_2;
    public GameObject coin;

   
    public override void Init()
    {
        horse.transform.position = post_1.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return horse.transform.DOMove(post_2.transform.position, 1).WaitForCompletion();
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(post_2.transform.position.x, post_2.transform.position.y + 0.5f, post_2.transform.position.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = post_2.transform.position;
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}