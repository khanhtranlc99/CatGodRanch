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
    public TMP_Text tvName;
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
    public Sprite normalBg;
    public Sprite rageBg;
    public Sprite superBg;
    public Image decoreText;
    public Color32 normalColor/* = new Color32(110,157,244,255)*/;
    public Color rageColor /*= new Color32(199, 232, 247, 255)*/;
    public Color superColor /*= new Color32(254, 208, 122, 255)*/;

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
                bgCard.sprite = normalBg;
                decoreText.color = normalColor;
                break;
            case CardRank.Rare:
                bgCard.sprite = rageBg;
                decoreText.color = rageColor;
                break;
            case CardRank.SuperRare:
                bgCard.sprite = superBg;
                decoreText.color = superColor;
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
        GameController.Instance.musicManager.PlayClickSound();
        GamePlayController.Instance.playerContain.animalController.SpwanAnimals(animalsData.prefabAnimals,1);
        CardAnimalsBox.instance.Close();
        if (GamePlayController.Instance.tutCard.isStart && UseProfile.TutGamePlayCard_Step_1 == false)
        {
          TutGamePlayCard_Step_1_5.Instance.HandleShowHand();
        }
    }
}
