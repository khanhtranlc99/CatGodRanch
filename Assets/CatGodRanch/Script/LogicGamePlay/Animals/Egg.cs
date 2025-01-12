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
     
        if (day <= 0)
        {
            var ran = Random.RandomRange(0,100);
            var temp = new AnimalsDataProperty();
            if (GamePlayController.Instance.tutCard.isStart && !UseProfile.TutGamePlayCard_Step_1)
            {
                ran = 81;
            }
                if (ran <= 20)
            {
                 temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Chicken);    
            }
            if (ran > 20 && ran <= 40)
            {
                 temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Rooster);      
            }
            if (ran > 40 && ran <= 60)
            {
                 temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Turkey);          
            }
            if (ran > 60 && ran <= 80)
            {
                temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Duck);
            }
            if (ran > 80 && ran <= 100)
            {
                temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Pigeon);
            }
            yield return StartCoroutine(HandleTranform());
            SpwanAnimals(temp.prefabAnimals);
        //    GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
            day = 3;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            SimplePool2.Despawn(this.gameObject);
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

