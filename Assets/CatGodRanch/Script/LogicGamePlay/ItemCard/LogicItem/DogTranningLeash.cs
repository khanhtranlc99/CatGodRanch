using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTranningLeash : ItemBase
{
    public override void Init()
    {
        tvNum.text = "";
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        yield return null;
    }
}
