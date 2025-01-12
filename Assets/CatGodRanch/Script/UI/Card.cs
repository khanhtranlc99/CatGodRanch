using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    public Image bgCard;
    public Image iconAnimals;
    public Image iconType;
    public Text tvName;
    public TMP_Text tvContent;
    public TMP_Text tvNumbDaily;
    public Text tvPrice;
    public Button btnCard;
    public AnimalsDataProperty animalsData;
    public Transform decorText;
    public AnimTutBase tempTut;
    CardBase card;
    public RectTransform rectTransformText;
    public GameObject blindPanel;
    public void Init(CardBase dataParam)
    {
        animalsData = dataParam.animalsDataProperty;
        card = dataParam;
        iconAnimals.sprite = animalsData.spriteAvatar;
        iconType.sprite = animalsData.spriteAnimalsType;
        tvName.text = animalsData.name;
        tvContent.text = animalsData.content;
        tvNumbDaily.text = "" + animalsData.coinPlus;
        tvPrice.text = "Buy: " + animalsData.price;
        btnCard.onClick.RemoveAllListeners();
        btnCard.onClick.AddListener(OnClick);
        switch (dataParam.cardRank)
        {
            case CardRank.Normal:
                bgCard.color = Color.gray;
                break;
            case CardRank.Rare:
                bgCard.color = Color.blue;
                break;
            case CardRank.SuperRare:
                bgCard.color = Color.yellow;
                break;    
        }

        if (tempTut != null)
        {
            Destroy(tempTut.gameObject);
            tempTut = null;
        }
        tempTut = Instantiate(card.tutBase);   
        tempTut.transform.SetParent(decorText, false);
        tempTut.transform.SetAsFirstSibling();
        tempTut.transform.localScale = new Vector3(1, 1, 1);
        tempTut.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        tempTut.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        HandleTutCard();
    }
    private IEnumerator initTemp()
    {
        yield return new WaitForSeconds(0.5f);
        if (tempTut != null)
        {
            tempTut.Init();
        }
    }    

     
     public void HandleTutCard()
    {
        StartCoroutine(initTemp());

    }

    public void HandleOnText()
    {
        rectTransformText.gameObject.SetActive(true);
       
    }
    public void HandleOffText()
    {
        rectTransformText.gameObject.SetActive(false);
        
    }
    public void HandleShowBlindPanel()
    {
        blindPanel.SetActive(true);
        iconType.color = new Color32(0,0,0,159);

    }
    public void HandleOffBlindPanel()
    {
        blindPanel.SetActive(false);
        iconType.color = Color.white;
    }

    private void OnClick( )
    {
    
        GamePlayController.Instance.playerContain.animalController.SpwanAnimals(animalsData.prefabAnimals);
        CardAnimalsBox.instance.Close();
        if (GamePlayController.Instance.tutCard.isStart && UseProfile.TutGamePlayCard_Step_1 == false)
        {
          TutGamePlayCard_Step_1_5.Instance.HandleShowHand();
        }
    }
}
