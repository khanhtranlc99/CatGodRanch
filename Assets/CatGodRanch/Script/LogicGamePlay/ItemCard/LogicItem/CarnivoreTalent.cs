using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreTalent : ItemBase
{
    bool isListener = false;
    public override void Init()
    {
        count += 1;
        tvNum.text = count.ToString();
        if (!isListener)
        {
            isListener = true;
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.HUNT_SUGGET, HandEffect);
        }

    }
    private void HandEffect(object param)
    {
        var temp  = (AnimalsBase)param;
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.35f).OnComplete(delegate {
            this.transform.DOScale(new Vector3(1, 1, 1), 0.35f).OnComplete(delegate {

                Debug.LogError("CarnivoreTalent");
                temp.coinPlus += 1;
            });
        });
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        yield return null;
    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandEffect);
    }

}
