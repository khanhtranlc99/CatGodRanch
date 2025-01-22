using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using DG.Tweening;
public class Egg : AnimalsBase
{
    public TMP_Text tvDay;
    public int day = 3;
    public Sprite parth_1;
    public Sprite parth_2;
    public Sprite parth_3;

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
        if (UseProfile.OnSound)
        {
            audioSource.PlayOneShot(sfx);
        }
        if (day <= 0)
        {
            spriteRender.sprite = parth_3;
            var ran = Random.RandomRange(0,100);
            var temp = new AnimalsDataProperty();
            //if (GamePlayController.Instance.tutCard.isStart && !UseProfile.TutGamePlayCard_Step_1)
            //{
            //    ran = 81;
            //}
            if(!GamePlayController.Instance.isEgg)
            {
                GamePlayController.Instance.isEgg = true;
                temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Duck);
            }    
            else
            {
                temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Turkey);
            }
             
            yield return StartCoroutine(HandleTranform());
            SpwanAnimals(temp.prefabAnimals);
            //    GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
          
          
            SimplePool2.Despawn(this.gameObject);
            spriteRender.sprite = parth_1;
            day = 3;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        }
        else
        {
            spriteRender.transform.DOKill();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Join(this.transform.DOJump(this.transform.position, 1.5f, 1, 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
            sequence.Append(spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
            yield return sequence.WaitForCompletion();
            if(day == 2)
            {
                yield return StartCoroutine(HandleTranform());
                spriteRender.sprite = parth_2;
            }
            if (day == 1)
            {
                yield return StartCoroutine(HandleTranform());
                spriteRender.sprite = parth_2;
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
    public override IEnumerator HandleClaimCoin()
    {
        yield return null;
    }

}

