using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ChickenAnim : AnimTutBase
{
    public Vector3 post1Rooster;
    public GameObject chicken;
    public GameObject rooster;
    public GameObject egg;
    public GameObject smoke;

   
    public override void Init ()
    {
        post1Rooster = rooster.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return rooster.transform.DOMove(chicken.transform.position, 1).WaitForCompletion();
        smoke.SetActive(true);
        yield return new WaitForSeconds(1);
        smoke.SetActive(false);
        yield return rooster.transform.DOMove(post1Rooster, 1).WaitForCompletion();
        yield return chicken.transform.DOJump(chicken.transform.position, 1, 1, 0.5f).WaitForCompletion();
        egg.SetActive(true);
        yield return new WaitForSeconds(1);
        egg.SetActive(false);
        Init();
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

}
