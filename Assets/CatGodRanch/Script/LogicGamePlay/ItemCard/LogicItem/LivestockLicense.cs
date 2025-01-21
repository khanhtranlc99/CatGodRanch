using DG.Tweening;
using EventDispatcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivestockLicense : ItemBase
{
    bool isListener = false;
    public override void Init()
    {
        count += 1;
        if(count > 1)
        {
            tvNum.text = count.ToString();
        }      
        if(!isListener)
        {
            isListener = true;
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.BUY_ANIMALS_SUCCEST, HandEffect);
        }
    
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        yield return null;
    }

    private void HandEffect(object param)
    {
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.35f).OnComplete(delegate {
            this.transform.DOScale(new Vector3(1, 1, 1), 0.35f).OnComplete(delegate {

                StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2*count, transform.position, true));
            });

        });

    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.BUY_ANIMALS_SUCCEST, HandEffect);
    }


}
