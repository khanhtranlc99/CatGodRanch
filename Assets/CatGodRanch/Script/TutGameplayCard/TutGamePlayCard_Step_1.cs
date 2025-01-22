using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutGamePlayCard_Step_1 : TutorialBase
{
    public static TutGamePlayCard_Step_1 Instance;
    GameObject hand;
    public GameObject hand1;
    public CanvasGroup canvasGroup;
    public Image blindPanel;
    public GameObject snow;
    public PlayerContain playerContain
    {
        get
        {
            return GamePlayController.Instance.playerContain;
        }
    }
    public override bool IsCanEndTut()
    {
        if (hand != null)
        {
            Destroy(hand.gameObject);
        }
        return true;
    }

    private void Start()
    {
        Instance = this;
    }
    public override void StartTut()
    {
        GamePlayController.Instance.playerContain.animalController.sumCoinBar.tmp.color = new Color32(255, 255, 255, 255);
        controller.isStart = true;
        var hen = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[0];
        hen.Init();
        Debug.LogError("Rooster");
        StartCoroutine(StartHen());
        IEnumerator StartHen()
        {
            yield return hen.HandleEffect();
            yield return hen.HandleEffect();
            yield return new WaitForSeconds(1);
         
            yield return canvasGroup.DOFade(1, 1).WaitForCompletion();
            var temp = GamePlayController.Instance.playerContain.cardController;
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Duck).prefabAnimals);
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Pigeon).prefabAnimals);
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Magpie).prefabAnimals);
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Penguin).prefabAnimals);
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Crow).prefabAnimals);
            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Ostrich).prefabAnimals);
             
            yield return new WaitForSeconds(1);
            yield return canvasGroup.DOFade(0, 1).WaitForCompletion();
       //     GamePlayController.Instance.playerContain.animalController.sumCoinBar.tmp.color = new Color32(255, 255, 255, 255);
            foreach (var item in playerContain.animalController.lsAnimalsBases)
            {
                StartCoroutine(item.HandleClaimCoin());
            }
            yield return new WaitForSeconds(2);
            var tempDoor = GamePlayController.Instance.playerContain.animalController.lsDoor[1];
            yield return tempDoor.transform.DOScale(Vector3.one * 1.2f, 0.7f).WaitForCompletion();
            yield return tempDoor.transform.DOScale(Vector3.one, 0.7f).WaitForCompletion();
            yield return tempDoor.doorSprite.DOColor(Color.white, 0.5f).WaitForCompletion();
            StartCoroutine(GamePlayController.Instance.playerContain.animalController.HandleMoveIn(false));

            playerContain.animalController.SpwanAnimals(temp.GetCardName(AnimalsName.Eagle).prefabAnimals, true, true);
            var Eagle = GamePlayController.Instance.playerContain.postYardController.postTut_Egle_first.animalsBase;
         
            Eagle.transform.position = GamePlayController.Instance.playerContain.itemController.postYardParent.transform.position;
            yield return new WaitForSeconds(3);
            yield return Eagle.transform.DOMove(new Vector3(Eagle.postYardBase.transform.position.x, Eagle.postYardBase.transform.position.y, Eagle.postYardBase.transform.position.z), 1).WaitForCompletion();
            yield return new WaitForSeconds(1);
            blindPanel.DOFade(0.7f,1).WaitForCompletion();
            snow.gameObject.SetActive(true);
            Eagle.AnimRotateInMove();

            yield return new WaitForSeconds(3);
            yield return Eagle.transform.DOJump(Eagle.transform.position, 1.2f, 2, 1).WaitForCompletion();
            yield return Eagle.transform.DORotate(new Vector3(0,0,-100),1).WaitForCompletion();
            yield return new WaitForSeconds(1);
            snow.gameObject.SetActive(false);
            blindPanel.DOFade(0, 1).WaitForCompletion();
            Eagle.HandleActionDie();
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(GamePlayController.Instance.playerContain.animalController.HandleMoveOut(false));
            yield return new WaitForSeconds(1);
            Initiate.Fade(SceneName.LOADING_SCENE, Color.black, 2f);
            Debug.LogError("tempDoor");
        }


    }




    public IEnumerator Show(Transform param)
    {
        yield return new WaitForEndOfFrame();
        hand = Instantiate(handTut);
        hand.transform.SetParent(param, false);
        hand.transform.position = new Vector3(param.position.x -1.5f, param.position.y -4, param.position.z);
        hand.gameObject.GetComponent<HandTut_Down_UI>().Init();
     
    }
    public IEnumerator Show2(Transform param)
    {
        yield return new WaitForEndOfFrame();
        hand = Instantiate(hand1);
        hand.transform.SetParent(param, false);
        hand.transform.position = new Vector3(param.position.x +1.5f, param.position.y-2.5f, param.position.z);
        hand.gameObject.GetComponent<HandTut_Down_UI>().Init();

    }
    public void HandleOffHandle()
    {
        if (hand != null)
        {
            Destroy(hand.gameObject);
        }
    }
    protected override void SetNameTut()
    {
       
    }
    public override void OnEndTut()
    {

    }
}
