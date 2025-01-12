using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class FreeRoll : MonoBehaviour
{
    public List<FreeRollData> lsData;

    public int GetfreeRoll
    { 
        get
        {
            return lsData[UseProfile.CurrentLevel].freeRoll;
        }
    }
    [Button]
    private void HandleInit()
    {
        for (int i = 0; i < lsData.Count; i++)
        {
            lsData[i].level = i + 1;

        }   
    }

}
[System.Serializable]
public class FreeRollData
{
    public int level;
    public int freeRoll;

}
