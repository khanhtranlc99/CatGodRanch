using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTalentCard : CardBase
{
    public override bool CanShow()
    {
        var temp = Random.RandomRange(0, 5);
        if (temp == 1)
        {
            return false;
        }
        return true;
    }
    public override void Init()
    {

    }
    public override void HandleAction()
    {

    }


}

