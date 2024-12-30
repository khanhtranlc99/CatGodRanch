using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tiger : AnimalsBase
{
    public List<AnimalsBase> lsAnimalsTarget;
    bool huntSuccess;
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
        huntSuccess = false;
        if (lsAnimalsTarget.Count > 0)
        {
            lsAnimalsTarget.Clear();
        }
        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null)
            {
                if (item.animalsBase.animalsName == AnimalsName.Lamp && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);            
                }
                if (item.animalsBase.animalsName == AnimalsName.Sheep && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Alpaca && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Goat && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Calf && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.WaterBuffalo && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Cow && item.animalsBase.huntAnimal == null)
                {
                    lsAnimalsTarget.Add(item.animalsBase);
                }
            }
        }
        foreach(var item in lsAnimalsTarget)
        {
        
            item.huntAnimal = this;
        }
    }

    public override void InitState()
    {
    
    }



    public override void HandleActionDie()
    {
        base.HandleActionDie();
        StopAllCoroutines();
    }

    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {
            if (lsAnimalsTarget.Count > 0)
            {
                for (int i = lsAnimalsTarget.Count - 1; i >= 0; i--)
                {
                    if (lsAnimalsTarget[i] != null)
                    {
                        if (lsAnimalsTarget[i].lsAnimalsProtect.Count > 0)
                        {
                            huntSuccess = false;
                            yield return transform.DOMove(lsAnimalsTarget[i].gameObject.transform.position, 0.5f).WaitForCompletion();
                            foreach (var protect in lsAnimalsTarget[i].lsAnimalsProtect)
                            {
                                yield return StartCoroutine(protect.HandleActionProtect());
                            }
                            lsAnimalsTarget.Remove(lsAnimalsTarget[i]);
                            yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();
                        }
                        else
                        {
                            huntSuccess = true;
                            yield return transform.DOMove(lsAnimalsTarget[i].gameObject.transform.position, 0.5f).WaitForCompletion();
                            lsAnimalsTarget[i].HandleActionDie();
                            lsAnimalsTarget.Remove(lsAnimalsTarget[i]);
                            yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();

                            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(4, transform.position));

                        }
                    }
                }
            }
            yield return null;
            if (huntSuccess)
            {
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.HUNT_SUGGET, this);
            }
        }
        else
        {
            yield return null;
        }
      
    }


}
