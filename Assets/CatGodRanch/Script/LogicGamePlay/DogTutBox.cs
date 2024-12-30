using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogTutBox : MonoBehaviour
{
    public GameObject hand;
    public Button btnCard;
    private void Start()
    {
        btnCard.onClick.AddListener(delegate { HandleBtnCard(); });
    }
    public void HandleTest()
    {
        hand.SetActive(true);
   
    }  
    private void HandleBtnCard()
    {
        this.gameObject.SetActive(false);
        RandomCardBox.Setup(HomeController.Instance.animalsHomeController.animalsData).Show();
    }
    
}
