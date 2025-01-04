using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Penguin : AnimalsBase
{
    public bool CheckBirdAround
    {
        get
        {
            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public TMP_Text tvDay;
    int day = 3;
    public bool CanHandleEffect
    {
        get
        {
            if (huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
    public GameObject boxChat;
    public SpriteRenderer spriteRenderer;

    public override void Init()
    {
        SetUpPlus();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if (CanHandleEffect)
        {
            day -= 1;
          
            if (day <= 0)
            {
                tvDay.text = "";
                AnimRotateInMove();
                yield return this.transform.DOMove(GamePlayController.Instance.playerContain.animalController.penguinController.post.position, 1).WaitForCompletion();
                this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
                yield return this.transform.DOMove(postYardBase.transform.position, 1).WaitForCompletion();
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                AnimScale();

                var Ran = Random.Range(0, GamePlayController.Instance.playerContain.itemController.lsCardBase.Count);
                var name = GamePlayController.Instance.playerContain.itemController.lsCardBase[Ran];
                spriteRenderer.sprite = name.itemDataProperty.spriteAvatar;
                boxChat.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                boxChat.gameObject.SetActive(false);

                GamePlayController.Instance.playerContain.itemController.SpawnItem(name.itemDataProperty.itemName, true);
                day = 3;
                tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            }
            else
            {
                yield return this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();
                tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            }
          
        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        yield return null;
    }
    public override IEnumerator HandleClaimCoin()
    {
        yield return null;
    }
}
