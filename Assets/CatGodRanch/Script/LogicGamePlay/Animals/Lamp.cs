using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Lamp : AnimalsBase
{
    public TMP_Text tvDay;
    int day = 3;

   
    public bool CanHandleEffect
    {
        get
        {
            if(huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }    
            return true;
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
        if (CanHandleEffect)
        {
            day -= 1;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            if (day <= 0)
            {
                var ran = Random.RandomRange(0, 100);
                var temp = new AnimalsDataProperty();
                if (ran <= 33)
                {
                     temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Goat);
 
                }
                if (ran > 33 && ran <= 66)
                {
                     temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Alpaca);
                  
                }
                if (ran > 66 && ran <= 100)
                {
                     temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Sheep);
             
                }
                yield return StartCoroutine(HandleTranform());             
                SpwanAnimals(temp.prefabAnimals);
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.GROW_EXPRESS_SUCCEST);
                GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
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
