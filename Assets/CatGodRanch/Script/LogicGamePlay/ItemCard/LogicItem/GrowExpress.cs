using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowExpress : ItemBase
{
    bool isListener = false;
    public override void Init()
    {
        count += 1;
        tvNum.text = count.ToString();
        if (!isListener)
        {
            isListener = true;
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.GROW_EXPRESS_SUCCEST, HandEffect);
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

                StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(count, transform.position));
            });

        });
    
    }
    
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.GROW_EXPRESS_SUCCEST, HandEffect);
    }
}
