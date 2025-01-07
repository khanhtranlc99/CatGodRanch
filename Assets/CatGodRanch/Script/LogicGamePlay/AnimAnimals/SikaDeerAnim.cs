using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SikaDeerAnim : AnimTutBase
{
    public GameObject horse;
    public GameObject sikadeer;
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
        yield return new WaitForSeconds(1);
        yield return horse.transform.DOMove(post_2.transform.position, 1).WaitForCompletion();

        yield return sikadeer.transform.DOJump(sikadeer.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();

        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(sikadeer.transform.position.x, sikadeer.transform.position.y + 0.5f, sikadeer.transform.position.z), 1).WaitForCompletion();

        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = sikadeer.transform.position;
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}