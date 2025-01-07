using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SheepAnim : AnimTutBase
{
    public TMP_Text tvDay;
    public Image icon;
    public GameObject coin;
    int day = 3;
    public Vector3 post_Coin;

   
    public override void Init()
    {
        day = 3;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        post_Coin = coin.transform.position;
        StartCoroutine(HandleEffect());
    }
    public IEnumerator HandleEffect()
    {
        icon.transform.DOKill();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Join(icon.transform.DOJump(icon.transform.position, 1, 1, 0.5f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
        yield return sequence.WaitForCompletion();
        day -= 1;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
     

        if (day > 0)
        {
            coin.SetActive(true);
            coin.GetComponent<TMP_Text>().text = "-1" + "<sprite name=\"Coin\">";
            yield return coin.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
            coin.SetActive(false);
            coin.transform.position = post_Coin;
            StartCoroutine(HandleEffect());
        }
        else
        {
            tvDay.text = "";
            coin.SetActive(true);
            coin.GetComponent<TMP_Text>().text = "+7" + "<sprite name=\"Coin\">";
            icon.gameObject.SetActive(false);
            yield return coin.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
            coin.SetActive(false);
            coin.transform.position = post_Coin;
            icon.gameObject.SetActive(true);
            day = 3;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            yield return new WaitForSeconds(1.5f);
            Init();
        }
    }
   
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}