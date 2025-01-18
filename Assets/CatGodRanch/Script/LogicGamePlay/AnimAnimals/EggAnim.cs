using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EggAnim : AnimTutBase
{
    public TMP_Text tvDay;
    public Image icon;
    public List<Sprite> lsSprite;
    public Sprite iconEgg;
    int day = 3;
    public Sprite path_1;
    public Sprite path_2;
    public Sprite path_3;   
    
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
        sequence.Join(icon.transform.DOJump(icon.transform.position, 1, 1, 0.5f));
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
            icon.sprite = path_2;

            StartCoroutine(HandleEffect());
        }
        else
        {
            icon.sprite = path_3;
            StartCoroutine(HandleTranform());
        }
       

    }
    public IEnumerator HandleTranform()
    {
        

        var rand = Random.Range(0, lsSprite.Count);
        icon.sprite = lsSprite[rand];
        yield return new WaitForSeconds(1);
        icon.sprite = iconEgg;
        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
