using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
public class AnimalController : MonoBehaviour
{
    PlayerContain playerContain;
    public List<AnimalsBase> lsAnimalsBases;
    public List<AnimalsBase> lsTempAnimalsBases;
    public DuckController duckController;
    public PenguinController penguinController;
    public ReinDeerController reinDeerController;
    public Transform postHome;
    public Button btnNextDay;
    public AudioClip closeDoor;
    public AudioClip openDoor;
    public GameObject vfxSmoke;
    public AudioClip owlSfx;
    public AudioClip birdSfx;
    public List<Door> lsDoor;
    public SumCoinBar sumCoinBar;
    public void Init(PlayerContain playerContainParam)
    {
        playerContain = playerContainParam;
        btnNextDay.onClick.AddListener(delegate {
            GameController.Instance.musicManager.PlayClickSound();
            HandleActionPassDay();
            btnNextDay.gameObject.SetActive(false);
        });
        lsTempAnimalsBases = new List<AnimalsBase>();
        btnNextDay.transform.localScale = Vector3.zero;
        btnNextDay.transform.DOScale(Vector3.one, 1);
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
            temp.GetComponent<AnimalsBase>().SetOrderInLayer(tempPost.id);
            var tempSmoke = SimplePool2.Spawn(vfxSmoke);
            tempSmoke.transform.position = tempPost.transform.position;
            tempSmoke.transform.Rotate(new Vector3(-35, 0, 0));
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
    public void SpwanAnimals(GameObject animalsBase, int sound)
    {

        var tempPost = playerContain.postYardController.GetRandomEmptyPost;
        if (tempPost != null)
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
            temp.GetComponent<AnimalsBase>().Init();
            temp.GetComponent<AnimalsBase>().SetOrderInLayer(tempPost.id);
            var tempSmoke = SimplePool2.Spawn(vfxSmoke);
            tempSmoke.transform.position = tempPost.transform.position;
            tempSmoke.transform.Rotate(new Vector3(-35, 0, 0));
            temp.GetComponent<AnimalsBase>().HandleSound();
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
    public void SpwanAnimals(GameObject animalsBase, bool tut)
    {

        var tempPost = playerContain.postYardController.postTut_Chicken_first;
        if (tempPost != null)
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
            temp.GetComponent<AnimalsBase>().Init();
            temp.GetComponent<AnimalsBase>().SetOrderInLayer(tempPost.id);
            var tempSmoke = SimplePool2.Spawn(vfxSmoke);
            tempSmoke.transform.position = tempPost.transform.position;
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
       GamePlayController.Instance.tutGamePlay.NextTut();
        TutGamePlayCard_Step_1_5.Instance.HandleOffHand();
        if (GamePlayController.Instance.tutCard.isStart && UseProfile.TutGamePlayCard_Step_1 == true)
        {
            GamePlayController.Instance.tutCard.NextTut();
        }
        StartCoroutine(HandleMoveIn());
    }
    public IEnumerator HandleMoveIn( )
    {
        GameController.Instance.musicManager.PlayOneShot(owlSfx);
    
        GamePlayController.Instance.gameScene.HandleOffOnclickButton();
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
            item.SetCurrentInLayer();
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
        GameController.Instance.musicManager.PlayOneShot(closeDoor);
        Sequence sequence = DOTween.Sequence();
        foreach(var item in lsDoor)
        {
            sequence.Join(item.closeDoor);
        }
        yield return sequence.WaitForCompletion();
        playerContain.dayController.PassDay(delegate { StartCoroutine(HandleMoveOut()); });    
    }

    public IEnumerator HandleMoveOut()
    {
      
      
        GameController.Instance.musicManager.PlayOneShot(openDoor);
        Sequence sequence = DOTween.Sequence();
        foreach (var item in lsDoor)
        {
            sequence.Join(item.openDoor);
        }
        yield return sequence.WaitForCompletion();
        GameController.Instance.musicManager.PlayOneShot(birdSfx);
        GamePlayController.Instance.playerContain.inputController.lockInput = false;
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
                item.GetComponent<AnimalsBase>().SetOrderInLayer(randomPost.id);
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
                item.GetComponent<AnimalsBase>().SetOrderInLayer(randomPost.id);
                runningCoroutines.Add(StartCoroutine(item.HandleActionMove(randomPost.post.position)));
            }
        }
        foreach (var coroutine in runningCoroutines)
        {
            yield return coroutine;
        }
        yield return StartCoroutine(sumCoinBar.HandleMoveIn()) ;
        for (int i = lsAnimalsBases.Count -1; i >= 0; i-- )
        {
            if(lsAnimalsBases[i] != null)
            {
                lsAnimalsBases[i].Init();
            }
        }
        for (int i = lsAnimalsBases.Count - 1; i >= 0; i--)
        {
            int index = i;
            if (lsAnimalsBases[index] != null && lsAnimalsBases[index].gameObject.activeSelf)
            {
                yield return StartCoroutine(lsAnimalsBases[index].HandleEffect());
            }
        }
     

        for (int i = lsAnimalsBases.Count - 1; i >= 0; i--)
        {
            if (lsAnimalsBases[i] != null && lsAnimalsBases[i].gameObject.activeSelf)
            {
                yield return StartCoroutine(lsAnimalsBases[i].HandleClaimCoin());
            }
        }
        for (int i = lsAnimalsBases.Count - 1; i >= 0; i--)
        {

            if (!lsAnimalsBases[i].gameObject.activeSelf)
            {
                lsAnimalsBases.Remove(lsAnimalsBases[i]);
            }
        }
        if (playerContain.itemController.lsCurrentItem.Count > 0)
        {
            foreach(var item in playerContain.itemController.lsCurrentItem)
            {
                yield return StartCoroutine(item.HandleEffectItemIEnumrator());
            }
        }

        yield return StartCoroutine(sumCoinBar.SpawnSumCoin());

        if (GamePlayController.Instance.tutCard.isStart && !UseProfile.TutGamePlayCard_Step_1)
        {
         
            UseProfile.TutGamePlayCard_Step_1 = true;
            GamePlayController.Instance.tutCard.NextTut();
        }
        else
        {
            if (playerContain.dayController.currentDayType == DayType.Work)
            {
                CardAnimalsBox.Setup().Show();
            }
            if (playerContain.dayController.currentDayType == DayType.Pay)
            {
                PayBillBox.Setup(playerContain.coinController.targetCoin, playerContain).Show();
            }
        }

        GamePlayController.Instance.gameScene.HandleOnOnclickButton();

    }


}
