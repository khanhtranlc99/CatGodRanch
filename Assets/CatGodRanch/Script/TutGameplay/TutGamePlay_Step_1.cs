using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TutGamePlay_Step_1 : TutorialBase
{
    public Transform postCanvas;
    public override bool IsCanEndTut()
    {
 
        return true;
    }

    public override void StartTut()
    {
     
      if(UseProfile.CurrentLevel == 1)
        {
            StartCoroutine(HandleTut());
        }
    }
    public PlayerContain playerContain
    {
        get
        {
            return GamePlayController.Instance.playerContain;
        }
    }

    private IEnumerator HandleTut()
    {
        yield return new WaitForEndOfFrame();
        //var temp = Instantiate(handTut);
        //temp.transform.SetParent(postCanvas, false);
        //temp.GetComponent<NoticeController>().Init();
        GamePlayController.Instance.gameScene.HandleOffButton();
        GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(false);
        HandleSpawnChicken();
   
     

    }
    public void HandleSpawnChicken()
    {
        var temp = GamePlayController.Instance.playerContain.cardController;
        playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Chicken).prefabAnimals, true);
        playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Eagle).prefabAnimals, true, true);
        playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Pigeon).prefabAnimals, true, true, true);

        var chicken = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[0];
        var Pigeon = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[2];
        var Egle = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[1];
        Egle.AnimRotateInMove();
        Egle.transform.position = GamePlayController.Instance.playerContain.itemController.postYardParent.transform.position;
        
        StartCoroutine(HandClaimCoin());
        IEnumerator HandClaimCoin()
        {
            yield return StartCoroutine(chicken.HandleClaimCoin());
            yield return StartCoroutine(Pigeon.HandleClaimCoin());
          
            Egle.transform.DOMove(new Vector3(Egle.postYardBase.transform.position.x, Egle.postYardBase.transform.position.y, Egle.postYardBase.transform.position.z), 1).SetDelay(1).
                OnComplete(delegate { Egle.Init(); StartCoroutine(enumerator(Egle, chicken)); });
        }

    }


     



    private IEnumerator enumerator(AnimalsBase Egle, AnimalsBase chicken)
    {
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(Egle.HandleEffect());
        chicken.AnimRotateInMove();
        yield return Egle.transform.DOJump(Egle.transform.position, 1.2f, 2, 1).WaitForCompletion();
        Egle.GetComponent<Eagle>().boxChat.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        Egle.GetComponent<Eagle>().boxChat.gameObject.SetActive(false);
        var temp = GamePlayController.Instance.playerContain.animalController.duckController.postA;
        Egle.AnimRotateInMove();
        yield return Egle.transform.DOMove(new Vector3(temp.position.x, temp.position.y, temp.position.z), 1).WaitForCompletion();
        Egle.HandleActionDie();
        GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(Egle);
        chicken.AnimScale();
        yield return chicken.transform.DOJump(chicken.transform.position, 1.2f, 1, 1).WaitForCompletion();
        chicken.GetComponent<Chicken>().boxChat.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        GamePlayController.Instance.playerContain.animalController.sumCoinBar.tmp.color = new Color32(255, 255, 255, 0);
        CardAnimalsBox.Setup().Show();
        chicken.GetComponent<Chicken>().boxChat.gameObject.SetActive(false);
    }

    protected override void SetNameTut()
    {
       
    }
 
    public override void OnEndTut()
    {

    }
}
