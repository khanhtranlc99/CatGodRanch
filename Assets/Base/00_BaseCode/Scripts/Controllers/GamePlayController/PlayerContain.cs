using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum DayType
{ 
    Work,
    Pay
}
public enum DifficultyType
{
    IncreasedCoinOfferings,
    Offering,
    InitialCoin,
    StartWithBlockPlots,
    BlockPlotsEveryXDay,
    StartWithTrashBag
}

[System.Serializable]
public class DataDay
{
    public DayType dayType;
    [ShowIf("dayType", DayType.Pay)]
    public int numb;
}

[System.Serializable]
public class DataDifficulty
{
    public DifficultyType difficultyType;
    public int numb;
}

[System.Serializable]
public class DataLevel
{
    public int day;
    public DataDay dayType;

}


[System.Serializable]
public class LevelConfig
{
    public DataDifficulty dataDifficulty;
    public List<DataLevel> lsDataLevel;

}



public class PlayerContain : MonoBehaviour
{
    public LevelConfig levelConfig;
    public AnimalController animalController;
    public PostYardController postYardController;
    public CardController cardController;
    public ItemController itemController;
    public void Init()
    { 
    }

   


}
