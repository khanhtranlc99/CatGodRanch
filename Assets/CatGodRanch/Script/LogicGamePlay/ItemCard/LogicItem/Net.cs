using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : ItemBase
{
    public PostYardNest postYardNest;
    PostYardBase tempPostYardBase;
    public override void Init()
    {
        
      tempPostYardBase = GamePlayController.Instance.playerContain.postYardController.GetRandomPostYardNormal;
      var newYard = SimplePool2.Spawn(postYardNest);
        newYard.transform.parent = tempPostYardBase.transform.parent;
        newYard.transform.position = tempPostYardBase.transform.position;
        newYard.id = tempPostYardBase.id;
        foreach (var item in tempPostYardBase.lsNearYard)
        {
            newYard.lsNearYard.Add(item);
        }
        tempPostYardBase.gameObject.SetActive(false);
        GamePlayController.Instance.playerContain.postYardController.lsPostYardBases.Remove(tempPostYardBase);
        GamePlayController.Instance.playerContain.postYardController.lsPostYardBases.Add(newYard);
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        yield return null;
    }
}
