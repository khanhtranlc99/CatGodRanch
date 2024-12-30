using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
[CreateAssetMenu(menuName = "Datas/Unit", fileName = "Unit.asset")]
public class UnitData : ScriptableObject
{
   public List<DataUnit> lsData;


}

[System.Serializable]
public class DataUnit
{
    public UnitType unitType;
    public int level;
    public int atk;
    public int heath;
    public int hitPoint;
    public int def;
    public int speed;
    public int count;
}

