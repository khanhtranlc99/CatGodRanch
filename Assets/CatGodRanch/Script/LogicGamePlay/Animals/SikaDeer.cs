using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SikaDeer : AnimalsBase
{
    public List<PostYardBase> lsAnimalsPostAround;
    public PostYardBase tempPostYardBase;
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
    bool isListen = false;
    public override void Init()
    {
        SetUpPlus();
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.ANIMALS_MOVE, HandleEffectSikaDeer);
            isListen = true;
        }
      
       
     
      
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        yield return null;
    }
    private void HandleEffectSikaDeer(object param)
    {
        if (CanHandleEffect)
        {
            this.transform.DOJump(this.transform.position, 1.5f , 1 , 0.5f).OnComplete(delegate
            {
                StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            });
        }
     
    }
    public override void HandleActionDie()
    {
        base.HandleActionDie();
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.ANIMALS_MOVE, HandleEffectSikaDeer);
        isListen = false;
    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.ANIMALS_MOVE, HandleEffectSikaDeer);
    }
}