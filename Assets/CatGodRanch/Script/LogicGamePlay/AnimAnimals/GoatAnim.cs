using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoatAnim : AnimTutBase
{
    public GameObject goat;
    public GameObject wolf;
    public GameObject lamb;
    Vector3 post_1;


    public override void Init()
    {
        post_1 = wolf.transform.position;
     
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return wolf.transform.DOMove(goat.transform.position, 1).WaitForCompletion();
        goat.SetActive(false);
        lamb.SetActive(true);
        yield return wolf.transform.DOMove(post_1, 1).WaitForCompletion();
      
        yield return new WaitForSeconds(1);
        lamb.SetActive(false);
        goat.SetActive(true);
        yield return new WaitForSeconds(1);
        Init();

    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
