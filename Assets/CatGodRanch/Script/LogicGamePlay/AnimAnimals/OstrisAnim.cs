using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OstrisAnim : AnimTutBase
{
    public List<TutData> lsTranform;
    public Transform post_first;
    public GameObject ostrisAnim;
   
    public override void Init()
    {
        foreach (TutData data in lsTranform)
        {
            data.postCoinFirst = data.coin.transform.position;
        }
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        var random = Random.Range(0, lsTranform.Count);
      
        yield return ostrisAnim.gameObject.transform.DOJump(lsTranform[random].obj.transform.position, 0.5f, 1, 1).WaitForCompletion(); lsTranform[random].coin.SetActive(true);
        yield return lsTranform[random].coin.transform.DOMove(new Vector3(lsTranform[random].postCoinFirst.x, lsTranform[random].postCoinFirst.y + 0.5f, lsTranform[random].postCoinFirst.z), 1).WaitForCompletion();
        lsTranform[random].coin.gameObject.SetActive(false);
        lsTranform[random].coin.transform.position = lsTranform[random].postCoinFirst;
        yield return new WaitForSeconds(1);
        ostrisAnim.transform.position = post_first.position;
        yield return new WaitForSeconds(1);
        Init();

    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
