using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AnimalController : MonoBehaviour
{
    PlayerContain playerContain;
    public List<AnimalsBase> lsAnimalsBases;
    public List<AnimalsBase> lsTempAnimalsBases;
    public DuckController duckController;
    public PenguinController penguinController;
    public Transform postHome;
    public Button btnNextDay;
    public void Init(PlayerContain playerContainParam)
    {
        playerContain = playerContainParam;
        btnNextDay.onClick.AddListener(delegate {

            HandleActionPassDay();
            btnNextDay.gameObject.SetActive(false);
        });
        lsTempAnimalsBases = new List<AnimalsBase>();
    }
    public void SpwanAnimals(GameObject animalsBase)
    {
 
        var tempPost = playerContain.postYardController.GetRandomEmptyPost;
        if(tempPost != null)
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>() ;
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
            temp.GetComponent<AnimalsBase>().Init();
          
        }
        else
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = postHome.position;
            lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
 
        }
        btnNextDay.gameObject.SetActive(true);
        EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.BUY_ANIMALS_SUCCEST);
    }    
    public void HandleActionPassDay()
    {
       StartCoroutine(HandleMoveIn());
    }
    public IEnumerator HandleMoveIn( )
    {
        List<Coroutine> runningCoroutines = new List<Coroutine>();
        foreach (var item in lsAnimalsBases)
        {
            if (item.postYardBase != null)
            {
                item.postYardBase.animalsBase = null;
            }
            item.postYardBase = null;
            item.huntAnimal = null;
            item.lsAnimalsProtect.Clear();
            runningCoroutines.Add(StartCoroutine(item.HandleActionMove(postHome.position)));
        }
        foreach(var item in playerContain.postYardController.lsPostYardBases)
        {
            item.animalsBase = null;
        }    
        foreach (var coroutine in runningCoroutines)
        {
            yield return coroutine;
        }
        if(lsTempAnimalsBases.Count > 0)
        {
            foreach(var item in lsTempAnimalsBases)
            {
                lsAnimalsBases.Add(item);
            }
        }    

        playerContain.dayController.PassDay(delegate { StartCoroutine(HandleMoveOut()); });    
    }

    public IEnumerator HandleMoveOut()
    {
        lsAnimalsBases.Shuffle();
        lsTempAnimalsBases.Clear();
        duckController.InitState();
        List<Coroutine> runningCoroutines = new List<Coroutine>();
        if (lsAnimalsBases.Count <= playerContain.postYardController.lsPostYardBases.Count)
        {    
            foreach (var item in lsAnimalsBases)
            {
                var randomPost = playerContain.postYardController.GetRandomEmptyPost;
                randomPost.animalsBase = item.GetComponent<AnimalsBase>() ;
                item.GetComponent<AnimalsBase>().postYardBase = randomPost;
                runningCoroutines.Add(StartCoroutine(item.HandleActionMove(randomPost.post.position)));
            }
        }
        else
        {
            var temp = lsAnimalsBases.Count - playerContain.postYardController.lsPostYardBases.Count;
            for (int i = 0; i < temp; i ++)
            {
                lsTempAnimalsBases.Add(lsAnimalsBases[i]);
                lsAnimalsBases.Remove(lsAnimalsBases[i]);
            }
            foreach (var item in lsAnimalsBases)
            {
                var randomPost = playerContain.postYardController.GetRandomEmptyPost;
                randomPost.animalsBase = item.GetComponent<AnimalsBase>() ;
                item.GetComponent<AnimalsBase>().postYardBase = randomPost;
                runningCoroutines.Add(StartCoroutine(item.HandleActionMove(randomPost.post.position)));
            }
        }
        foreach (var coroutine in runningCoroutines)
        {
            yield return coroutine;
        }
        for(int i = lsAnimalsBases.Count -1; i >= 0; i-- )
        {
            if(lsAnimalsBases[i] != null)
            {
                lsAnimalsBases[i].Init();
            }
        }
        for (int i = lsAnimalsBases.Count - 1; i >= 0; i--)
        {
            if (lsAnimalsBases[i] != null)
            {
                yield return StartCoroutine(lsAnimalsBases[i].HandleEffect());
            }
        }
        for (int i = lsAnimalsBases.Count - 1; i >= 0; i--)
        {
            if (lsAnimalsBases[i] != null)
            {
                yield return StartCoroutine(lsAnimalsBases[i].HandleClaimCoin());
            }
        }
         if(playerContain.itemController.lsCurrentItem.Count > 0)
        {
            foreach(var item in playerContain.itemController.lsCurrentItem)
            {
                yield return StartCoroutine(item.HandleEffectItemIEnumrator());
            }
        }

        if (playerContain.dayController.currentDayType == DayType.Work)
        {
            CardAnimalsBox.Setup().Show();
        }
        if (playerContain.dayController.currentDayType == DayType.Pay)
        {
            PayBillBox.Setup(playerContain.coinController.targetCoin, playerContain).Show();
        }
   
    }


}
