using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Pig : AnimalsBase
{
    public TMP_Text tvDay;
    int day = 3;
    public override void Init()
    {
        SetUpPlus();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }

    public override void InitState()
    {
    
    }


    public override void InitRange()
    {
        
    }




    public override IEnumerator HandleEffect()
    {
        day -= 1;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        if (day <= 0)
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(12, transform.position));
            base.HandleActionDie();
        }
        else
        {
            spriteRender.transform.DOKill();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Join(this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
            yield return sequence.WaitForCompletion();
            AnimScale();
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";

        }
        yield return null;
    }


}
