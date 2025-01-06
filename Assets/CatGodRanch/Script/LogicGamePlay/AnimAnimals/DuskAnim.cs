using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DuskAnim : AnimTutBase
{
    public GameObject dusk_1;
    public GameObject dusk_2;
    public GameObject dusk_3;
    public GameObject coin_1;
    public GameObject coin_2;
    public GameObject coin_3;
    public GameObject post_1;
    public GameObject post_2;
    public Vector3 vec3_1;
    public Vector3 vec3_2;
    public Vector3 vec3_3;
    public Vector3 vec3_Coin_1;
    public Vector3 vec3_Coin_2;
    public Vector3 vec3_Coin_3;

   
    public override void Init ()
    {
        vec3_1 = dusk_1.transform.position;
        vec3_2 = dusk_2.transform.position;
        vec3_3 = dusk_3.transform.position;
        vec3_Coin_1 = coin_1.transform.position;
        vec3_Coin_2 = coin_2.transform.position;
        vec3_Coin_3 = coin_3.transform.position;
        StartCoroutine(HandleShowTut());
    }    
    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1f);
       Sequence sequence = DOTween.Sequence();
        sequence.Join(dusk_1.transform.DOMove(post_1.transform.position, 0.7f));
        sequence.Join(dusk_2.transform.DOMove(post_1.transform.position, 0.8f));
        sequence.Join(dusk_3.transform.DOMove(post_1.transform.position, 0.9f));
        yield return sequence.WaitForCompletion();
        dusk_1.transform.position = post_2.transform.position;
        dusk_2.transform.position = post_2.transform.position;
        dusk_3.transform.position = post_2.transform.position;
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Join(dusk_1.transform.DOMove(vec3_1, 0.7f));
        sequence2.Join(dusk_2.transform.DOMove(vec3_2, 0.8f));
        sequence2.Join(dusk_3.transform.DOMove(vec3_3, 0.9f));
        yield return sequence2.WaitForCompletion();
        coin_1.SetActive(true);
        coin_2.SetActive(true);
        coin_3.SetActive(true);
        Sequence sequence3 = DOTween.Sequence();
        sequence3.Join(coin_1.transform.DOMove(new Vector3(vec3_Coin_1.x, vec3_Coin_1.y + 0.5f, vec3_Coin_1.z), 1));
        sequence3.Join(coin_2.transform.DOMove(new Vector3(vec3_Coin_2.x, vec3_Coin_2.y + 0.5f, vec3_Coin_2.z), 1));
        sequence3.Join(coin_3.transform.DOMove(new Vector3(vec3_Coin_3.x, vec3_Coin_3.y + 0.5f, vec3_Coin_3.z), 1));
        yield return sequence3.WaitForCompletion();
        coin_1.SetActive(false);
        coin_2.SetActive(false);
        coin_3.SetActive(false);
        coin_1.transform.position = vec3_Coin_1;
        coin_2.transform.position = vec3_Coin_2;
        coin_3.transform.position = vec3_Coin_3;
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
