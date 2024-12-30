using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    public DataUnit dataUnit;
    public Animator animator;
    public GameObject model;
    public UpgradeData upgradeData;
     
    public int HP
    {
        get
        {
            return dataUnit.heath + upgradeData.HandleGetDataForLevel(dataUnit.unitType, dataUnit.level).data.heath;
        }
    }


    public abstract void Init();
    public abstract void Attack();
    public abstract void TakeDame();
    public abstract void Move();
    public abstract void SetAction();





}





public enum UnitType
{
    Dragon,
    sword,
    archer,
    

}



