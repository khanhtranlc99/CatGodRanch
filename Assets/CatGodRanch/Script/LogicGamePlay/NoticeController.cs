using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
public class NoticeController : MonoBehaviour
{
    public TMP_Text tmpContent;
    public Button btnOk;
    public GameObject dog;
    public Transform postDog;
    public GameObject boxChat;
    public HandDogTutHome hand;
 
   
    public void Init()
    {

        dog.transform.DOMove(postDog.position, 1).OnComplete(delegate
        {
            boxChat.SetActive(true);
            StartCoroutine(ShowText());
        });
        btnOk.onClick.AddListener(HandleClick);
    }    
    private IEnumerator ShowText()
    {
        yield return boxChat.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
        string fullText = "The farm is looking dangerous, we need to pay 10"  + "<sprite name=\"Coin\">" + " in 5 days";
        Tween tween = DOTween.To(() => 0, x =>
        {
            int charCount = Mathf.FloorToInt(x * fullText.Length);
            tmpContent.text = fullText.Substring(0, charCount);
        }, 1f, 2);
        yield return tween.WaitForCompletion();
        yield return new WaitForSeconds(1);

        GamePlayController.Instance.gameScene.topParent.transform.SetAsLastSibling();
        yield return StartCoroutine(GamePlayController.Instance.gameScene.HandleShowTop());
     
        hand.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        btnOk.gameObject.SetActive(true);
        btnOk.transform.DOScale(new Vector3(1,1,1), 0.5f);


    }

    private void HandleClick()
    {
       this.gameObject.SetActive(false);   
       GamePlayController.Instance.playerContain.cardController.HandleSpawnChicken();
        GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(false);
        GamePlayController.Instance.tutGamePlay.NextTut();

    }

}
