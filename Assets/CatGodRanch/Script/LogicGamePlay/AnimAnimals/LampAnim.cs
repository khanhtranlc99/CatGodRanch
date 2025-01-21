using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LampAnim : AnimTutBase
{
    public TMP_Text tvDay;
    public Image icon;
    public List<Sprite> lsSprite;
    public Sprite iconLamp;
    int day = 3;

    
    public override void Init()
    {
        day = 3;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        StartCoroutine(HandleEffect());
    }
    public IEnumerator HandleEffect()
    {
       
        Sequence sequence = DOTween.Sequence();
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Join(icon.transform.DOJump(icon.transform.position, 1, 1, 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(icon.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
        yield return sequence.WaitForCompletion();
        day -= 1;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        yield return new WaitForSeconds(1);

        if (day > 0)
        {
            StartCoroutine(HandleEffect());
        }
        else
        {
            tvDay.text = "";
            StartCoroutine(HandleTranform());
        }


    }
    public IEnumerator HandleTranform()
    {
      

        // Tạo một Sequence để kết hợp tween
        //Sequence sequence = DOTween.Sequence();

        //// Tween thay đổi màu sắc (fade)
        //sequence.Append(icon.DOColor(new Color32(255, 255, 255, 50), 0.3f))
        // .Join(icon.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.3f))

        // .Append(icon.DOColor(new Color32(255, 255, 255, 255), 0.3f))
        // .Join(icon.transform.DOScale(new Vector3(1, 1, 0), 0.3f))

        // .Append(icon.DOColor(new Color32(255, 255, 255, 50), 0.3f))
        // .Join(icon.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.3f))

        // .Append(icon.DOColor(new Color32(255, 255, 255, 255), 0.3f))
        // .Join(icon.transform.DOScale(new Vector3(1, 1, 0), 0.3f));

        //yield return sequence.WaitForCompletion();

        var rand = Random.Range(0, lsSprite.Count);
        icon.sprite = lsSprite[rand];
        yield return new WaitForSeconds(1);
        icon.sprite = iconLamp;
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
