using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Datas/UpgradeData", fileName = "UpgradeData.asset")]
public class UpgradeData : ScriptableObject
{
    public List<UpdateData> datas;
    public DataForLevel HandleGetDataForLevel(UnitType unitTypeParam, int level)
    {
        foreach (var data in datas)
        {
            if(data.type == unitTypeParam)
            {
                return data.GetDataForLevel(level);
            }
        }
        return null;
    }

     
}



[System.Serializable]
public class UpdateData
{
    public UnitType type;

    public List<DataForLevel> datas;

    public DataForLevel GetDataForLevel(int levelPram)
    {
        foreach (var data in datas)
        {
            if(data.level == levelPram)
            {
                return data;
            }
        }
        return null;
    }
}
[System.Serializable]
public class DataForLevel
{
    public int level;
    public Data data;
}
[System.Serializable]
public class Data
{
    public int atk;
    public int heath;
    public int hitPoint;
    public int def;
    public int speed;
    public int count;
}