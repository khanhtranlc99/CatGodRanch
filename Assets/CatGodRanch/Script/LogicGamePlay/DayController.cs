using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using DG.Tweening;
using System;
public class DayController : MonoBehaviour
{
    public Text tvDay;
    public List<Daybar> lsDaybars;
    PlayerContain playerContain;
    public List<DataLevel> lsCurrentData;
    public int currentDay;
    public int countDayBar;
    public int endDay;
    public Image panelDay;
    public List<DataLevel> lsTempBill;
    public DayType currentDayType;
    public DataLevel GetDataLevel
    {
        get
        {
            return lsCurrentData[countDayBar];
        }
    
    }    
    public int GetBill 
    {
        get
        {
            foreach(var item in playerContain.levelConfig.lsDataLevel)
            {
                if(item.dayType.dayType == DayType.Pay && !lsTempBill.Contains(item))
                {
                    lsTempBill.Add(item);
                    return item.dayType.numb;
                }
            }
            return 0;
        }
    }
    public int GetAllBill
    {
        get
        {
            var  temp = 0;
            foreach (var item in lsCurrentData)
            {
                temp += item.dayType.numb;
            }
            return temp;
        }
    }    
    public bool isWin 
    {
       get
        {
            if (currentDay >= playerContain.levelConfig.lsDataLevel.Count)
            {
                Debug.LogError("Win");
                return true;
            }
            return false;
        }        
    }    

    public void Init(PlayerContain paramPlayerContain)
    {
        playerContain = paramPlayerContain;
        lsTempBill = new List<DataLevel>();
        currentDay = 0;
        countDayBar = 0;
        endDay = playerContain.levelConfig.lsDataLevel.Count;
        SetStatus();
        playerContain.coinController.Init(GetBill);
    }

    public void SetStatus()
    {
     
        lsCurrentData = new List<DataLevel>();
        foreach(var item in playerContain.levelConfig.lsDataLevel)
        {
            if(lsCurrentData.Count < lsDaybars.Count && !item.wasPassDay)
            {
                item.wasPassDay = true;
                lsCurrentData.Add(item);
            }
        }
        for (int i = 0; i < lsCurrentData.Count; i ++)
        {
            lsDaybars[i].Init(lsCurrentData[i].dayType);
        }
        tvDay.text = currentDay + "/" + endDay  + "Day";
  
    }

    //[Button]
    public void PassDay(Action paramAction)
    {
        SetDay2();
        currentDayType = GetDataLevel.dayType.dayType;
      
        panelDay.DOColor(new Color32(0, 0, 0, 180), 0.5f).OnComplete(delegate {

            SetPassDay();
            panelDay.DOColor(new Color32(0,0,0,0),0.5f).SetDelay(0.5f).OnComplete(delegate {  paramAction?.Invoke(); });
        });
       


        void SetPassDay()
        {
         
            if (countDayBar < lsDaybars.Count)
            {
                lsDaybars[countDayBar].SetActiveBg();
                currentDay += 1;
                countDayBar += 1;
              
            }
            tvDay.text = currentDay + "/" + endDay + "Day";
        }

        void SetDay2()
        {
            if (countDayBar == lsDaybars.Count)
            {
             
                countDayBar = 0;
                for (int i = 0; i < lsDaybars.Count; i++)
                {
                    lsDaybars[i].SetDeActiveBg();
                }
                SetStatus();
            }
        }
    }

}
