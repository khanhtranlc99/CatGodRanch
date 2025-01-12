using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WordCanvas : MonoBehaviour
{
    public Image bgCard;
    public Image iconAnimals;
    public Image iconType;
    public TMP_Text tvName;
    public TMP_Text tvContent;
    public TMP_Text tvCoin;
    public TMP_Text tvPrice;
    AnimalsDataProperty animalsDataProperty; 
    public Button btnRemove;
    public Button btnBook;
    AnimalsBase animals;
    AnimTutBase animTutbase;
    int coinRemove;
    public Transform tranformPost;
    public GameObject parentText;
    public bool isShow;
    
    // Start is called before the first frame update
    public void InitState(AnimalsBase param)
    {
        parentText.SetActive(false);
        isShow = false;
        animals = param;
        animalsDataProperty = GamePlayController.Instance.playerContain.cardController.GetCardName(param.animalsName);
      
        iconAnimals.sprite = param.spriteRender.sprite;
        iconType.sprite = animalsDataProperty.spriteAnimalsType;
        tvName.text = param.animalsName.ToString();
        tvContent.text = animalsDataProperty.content;
        tvCoin.text = param.coinPlus.ToString();    
        switch (param.animalsRank)
        {
            case CardRank.Normal:
                bgCard.color = Color.gray;
                coinRemove = 5;
                break;
            case CardRank.Rare:
                bgCard.color = Color.blue;
                coinRemove = 8;
                break;
            case CardRank.SuperRare:
                bgCard.color = Color.yellow;
                coinRemove = 10;
                break;
        }
        tvPrice.text = "Remove -" + coinRemove + "<sprite name=\"Coin\">";
        btnRemove.onClick.RemoveAllListeners();
        btnBook.onClick.RemoveAllListeners();
        btnBook.onClick.AddListener(HandlOnClickBook);
        if (GamePlayController.Instance.playerContain.coinController.coin >= coinRemove)
        {
            btnRemove.interactable = true;
            btnRemove.onClick.AddListener(delegate { HandleOnClick(); });
        }
        else
        {
            btnRemove.interactable = false;
        }

        if (animTutbase != null)
        {
            Destroy(animTutbase.gameObject);
            animTutbase = null;
        }
        animTutbase = Instantiate( GamePlayController.Instance.playerContain.cardController.GetCardBaseByName(param.animalsName).tutBase);
        animTutbase.transform.SetParent(tranformPost, false);
        animTutbase.transform.SetAsFirstSibling();
        animTutbase.transform.localScale = new Vector3(0.007f, 0.007f, 0.007f);
        animTutbase.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        animTutbase.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        animTutbase.Init();
 
    }

    private void HandleOnClick()
    {
        GamePlayController.Instance.playerContain.coinController.HandlePlusCoin( -coinRemove);
        animals.HandleActionDie();
        GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(animals);
        GamePlayController.Instance.playerContain.inputController.wordCanvasController.HandleOff();
        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
    }
    private void HandlOnClickBook()
    {
        if(!isShow)
        {
            isShow = true;
            parentText.SetActive(true);
        }
        else
        {
            isShow = false;
            parentText.SetActive(false);
        }
        GamePlayController.Instance.tutGamePlay.NextTut();
    
    }
}
