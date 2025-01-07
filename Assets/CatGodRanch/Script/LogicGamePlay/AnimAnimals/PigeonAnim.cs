using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PigeonAnim : AnimTutBase
{
    public List<TutData> lsPigeon;
    public Vector3 post_1;
    public Vector3 post_2;

   
    public override void Init()
    {
        foreach (TutData data in lsPigeon)
        {
            data.postCoinFirst = data.coin.transform.position;
        }
        post_1 = lsPigeon[0].obj.gameObject.transform.position;
        post_2 = lsPigeon[1].obj.gameObject.transform.position;
        StartCoroutine(HandleShowTut());
    }

    private IEnumerator HandleShowTut()
    {
        var random = Random.Range(0, lsPigeon.Count);
        var temp = lsPigeon[random];


        yield return lsPigeon[0].obj.gameObject.transform.DOMove(lsPigeon[1].obj.transform.position, 1).WaitForCompletion();
        yield return lsPigeon[0].obj.transform.DOJump(lsPigeon[0].obj.transform.position, 1, 1, 0.5f).WaitForCompletion();
        lsPigeon[0].coin.gameObject.SetActive(true);
        yield return lsPigeon[0].coin.transform.DOMove(new Vector3(lsPigeon[0].postCoinFirst.x, lsPigeon[0].postCoinFirst.y + 0.5f, lsPigeon[0].postCoinFirst.z), 1).WaitForCompletion();
        lsPigeon[0].coin.gameObject.SetActive(false);
        lsPigeon[0].coin.transform.position = lsPigeon[0].postCoinFirst;
        yield return lsPigeon[0].obj.gameObject.transform.DOMove(post_1, 1).WaitForCompletion();


        yield return lsPigeon[1].obj.gameObject.transform.DOMove(lsPigeon[0].obj.transform.position, 1).WaitForCompletion();
        yield return lsPigeon[1].obj.transform.DOJump(lsPigeon[1].obj.transform.position, 1, 1, 0.5f).WaitForCompletion();
        lsPigeon[1].coin.gameObject.SetActive(true);
        yield return lsPigeon[1].coin.transform.DOMove(new Vector3(lsPigeon[1].postCoinFirst.x, lsPigeon[1].postCoinFirst.y + 0.5f, lsPigeon[1].postCoinFirst.z), 1).WaitForCompletion();
        lsPigeon[1].coin.gameObject.SetActive(false);
        lsPigeon[1].coin.transform.position = lsPigeon[1].postCoinFirst;

        yield return lsPigeon[1].obj.gameObject.transform.DOMove(post_2, 1).WaitForCompletion();
 
        Init();

    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
