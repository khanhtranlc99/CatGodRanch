using EventDispatcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleLion : AnimalsBase
{
    bool isListen = false;
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
    public override void Init()
    {
        SetUpPlus();
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.FEMALE_LION_HUNT_SUGGET, HandleEffectMaleLion);
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


    private void HandleEffectMaleLion(object param)
    {

        StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectMaleLion);
    }
    public override void HandleActionDie()
    {
        base.HandleActionDie();
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectMaleLion);
        isListen = false;
    }

}