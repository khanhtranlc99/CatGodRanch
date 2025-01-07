using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterbuffaloAnim : AnimTutBase
{
    public GameObject puddle;
    public GameObject grass;
    public GameObject waterbuffalo;
    public GameObject coin_1;
    public Vector3 post_Coin;
   
    public override void Init()
    {
        post_Coin = coin_1.transform.position;
        if(puddle.activeSelf)
        {
            puddle.SetActive(false);
            grass.SetActive(true);

            StartCoroutine(HandleShowTutGrass());
        }
        else
        {
            puddle.SetActive(true);
            grass.SetActive(false);

            StartCoroutine(HandleShowTut_Puddle());
        }
    }

    private IEnumerator HandleShowTutGrass()
    {
        yield return new WaitForSeconds(1);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Join(waterbuffalo.transform.DOJump(waterbuffalo.transform.position, 1, 1, 0.5f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
        yield return sequence.WaitForCompletion();

        coin_1.SetActive(true);
        coin_1.GetComponent<TMP_Text>().text = "+3" + "<sprite name=\"Coin\">";
        yield return coin_1.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
        coin_1.SetActive(false);
        coin_1.transform.position = post_Coin;
       
        Init();
    }
    private IEnumerator HandleShowTut_Puddle()
    {
        yield return new WaitForSeconds(1);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Join(waterbuffalo.transform.DOJump(waterbuffalo.transform.position, 1, 1, 0.5f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(waterbuffalo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
        yield return sequence.WaitForCompletion();

        coin_1.SetActive(true);
        coin_1.GetComponent<TMP_Text>().text = "+5" + "<sprite name=\"Coin\">";
        yield return coin_1.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
        coin_1.SetActive(false);
        coin_1.transform.position = post_Coin;
       
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
