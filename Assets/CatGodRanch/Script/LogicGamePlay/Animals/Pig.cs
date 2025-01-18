using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Pig : AnimalsBase
{
    public TMP_Text tvDay;
    int day = 3;
    public Sprite parth_1;
    public Sprite parth_2;
    public Sprite parth_3;
    public AudioClip jumpSfx;
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
            if (UseProfile.OnSound)
            {
                audioSource.PlayOneShot(sfx);
            }
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(12, transform.position));
            base.HandleActionDie();
            spriteRender.sprite = parth_1;
            day = 3;
        }
        else
        {
            if (UseProfile.OnSound)
            {
                audioSource.PlayOneShot(jumpSfx);
            }
            spriteRender.transform.DOKill();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Join(this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
            yield return sequence.WaitForCompletion();
            if (day == 2)
            {
                yield return StartCoroutine(HandleTranform());
                spriteRender.sprite = parth_2;
            }
            if (day == 1)
            {
                yield return StartCoroutine(HandleTranform());
                spriteRender.sprite = parth_3;
            }
            AnimScale();
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";

        }
        yield return null;
    }
    public IEnumerator HandleTranform()
    {
        spriteRender.transform.DOKill();

        // Tạo một Sequence để kết hợp tween
        Sequence sequence = DOTween.Sequence();

        // Tween thay đổi màu sắc (fade)
        sequence.Append(spriteRender.DOColor(new Color32(255, 255, 255, 50), 0.3f))
         .Join(spriteRender.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.3f))

         .Append(spriteRender.DOColor(new Color32(255, 255, 255, 255), 0.3f))
         .Join(spriteRender.transform.DOScale(new Vector3(1, 1, 0), 0.3f))

         .Append(spriteRender.DOColor(new Color32(255, 255, 255, 50), 0.3f))
         .Join(spriteRender.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 0.3f))

         .Append(spriteRender.DOColor(new Color32(255, 255, 255, 255), 0.3f))
         .Join(spriteRender.transform.DOScale(new Vector3(1, 1, 0), 0.3f));

        yield return sequence.WaitForCompletion();

        yield return null;
    }

}
