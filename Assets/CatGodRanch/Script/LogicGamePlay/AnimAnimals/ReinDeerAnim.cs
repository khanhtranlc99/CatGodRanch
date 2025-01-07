using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.IK;

public class ReinDeerAnim : AnimTutBase
{
    public GameObject reinDeer;
    public GameObject lamb;

    public Vector3 reinDeer_post;
    public Vector3 lamb_post;
    public GameObject post_2;
    public GameObject coin;

    public override void Init()
    {
        reinDeer_post = reinDeer.transform.position;
        lamb_post = lamb.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return reinDeer.transform.DOMove(lamb_post, 0.7f).SetEase(Ease.InOutBack).WaitForCompletion();

        yield return lamb.transform.DOJump(post_2.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();
        yield return reinDeer.transform.DOMove(reinDeer_post, 1).WaitForCompletion();
        coin.GetComponent<TMP_Text>().text = Random.Range(5,15) + "<sprite name=\"Coin\">";
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(reinDeer_post.x, reinDeer_post.y + 0.5f, reinDeer_post.z), 1).WaitForCompletion();

        lamb.transform.position = lamb_post ;
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = reinDeer.transform.position;
        yield return new WaitForSeconds(1);
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}