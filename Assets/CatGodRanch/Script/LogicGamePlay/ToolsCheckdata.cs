using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class ToolsCheckdata : MonoBehaviour
{
    public LevelConfig LevelConfig;
    public int idLevel;
    
    [Button]
    private void Check()
    {
        var pathLevel = "Levels/Level_{0}";
        TextAsset lvJson = Resources.Load<TextAsset>(string.Format(pathLevel,  idLevel));
        LevelConfig  = JsonUtility.FromJson<LevelConfig>(lvJson.ToString());
        int sum = 0;
       
        for (int i = 0; i < LevelConfig.lsDataLevel.Count; i++)
        {
            LevelConfig.lsDataLevel[i].day = i + 1;
            sum += LevelConfig.lsDataLevel[i].dayType.numb;
        }
        if (sum != LevelConfig.dataDifficulty.rewardCoin)
        {
            Debug.LogError("Level_" + idLevel + "ErorrSum");
        }
        else
        {
            Debug.LogError("Level_" + idLevel + "_OKOK");
        }
    }    
}
