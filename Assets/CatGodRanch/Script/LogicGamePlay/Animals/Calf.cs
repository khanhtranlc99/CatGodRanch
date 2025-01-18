using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Calf : AnimalsBase
{
   
    public TMP_Text tvDay;
    int day = 5;
    public AudioClip jumpSfx;
    public bool NearEater
    {
        get
        {
            foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.animalsBase != null && item.animalsBase.animalsName == AnimalsName.Tiger)
                {
                    return true;
                }
            }
            return false;
        }
    }
 
    public bool CanHandleEffect
    {
        get
        {
            if (NearEater )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public override void Init()
    {
        SetUpPlus();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }
    public override void InitRange()
    {
         
    }
    public override void InitState()
    {
       
    }



  


    public override IEnumerator HandleEffect()
    {
        day -= 1;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        if (CanHandleEffect)
        {
            day -= 1;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            if (day <= 0)
            {
                var ran = Random.RandomRange(0, 100);
                var temp = new AnimalsDataProperty();
                if (ran <= 50)
                {
                     temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.WaterBuffalo);
                 
                }
                else
                {
                     temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Cow);
                
                }
                if (UseProfile.OnSound)
                {
                    audioSource.PlayOneShot(sfx);
                }
                yield return StartCoroutine(HandleTranform());
                SpwanAnimals(temp.prefabAnimals);
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.GROW_EXPRESS_SUCCEST);
                //GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
                day = 5;
                tvDay.text = day.ToString() + "<sprite name=\"Time\">";
                SimplePool2.Despawn(this.gameObject);
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
                AnimScale();
                tvDay.text = day.ToString() + "<sprite name=\"Time\">";

            }
        }
        yield return null;
    }
    public void SpwanAnimals(GameObject animalsBase)
    {
        var tempPost = postYardBase;
        if (tempPost != null)
        {
            postYardBase.animalsBase = null;
            postYardBase = null;
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
        }
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