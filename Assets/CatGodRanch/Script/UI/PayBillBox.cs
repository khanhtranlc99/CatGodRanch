using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PayBillBox : BaseBox
{
    public static PayBillBox _instance;
    public static PayBillBox Setup(int paramPrice, PlayerContain paramPlayerContain)
    {
        if (_instance == null)
        {
            _instance = Instantiate(Resources.Load<PayBillBox>(PathPrefabs.PAY_BILL_BOX));
            _instance.Init(paramPlayerContain);
        }
        _instance.InitState(paramPrice);
        return _instance;
    }

    public Text tvMissingMoney;
    public Text tvPrice;
    public Button btnPay;
    public Button btnAds;
    PlayerContain playerContain;
    public int targetCoin;
    public Button homeBtn;
    public AudioClip sfxPopup;
    private void Init(PlayerContain paramPlayerContain)
    {
        playerContain = paramPlayerContain;
        btnPay.onClick.AddListener(HandleBtnPay);
        btnAds.onClick.AddListener(HandleBtnAds);
        homeBtn.onClick.AddListener(HandleHome);
    }

    private void InitState(int paramPrice)
    {
        GameController.Instance.musicManager.PlayOneShot(sfxPopup);
       targetCoin = paramPrice;
        tvPrice.text = "" + targetCoin;
    
        if (playerContain.coinController.coin >= paramPrice)
        {
            btnPay.interactable = true;
            btnAds.gameObject.SetActive(false);
            homeBtn.gameObject.SetActive(false);
        }
        else
        {
            btnPay.interactable = false;
            btnAds.gameObject.SetActive(true);
            homeBtn.gameObject.SetActive(true);
            tvMissingMoney.text = "" + (targetCoin - playerContain.coinController.coin );
        }
     
    }


    private void HandleBtnPay()
    {
        GameController.Instance.musicManager.PlayClickSound();
        playerContain.coinController.HandlePlusCoin(-targetCoin);
        Close();
        if (playerContain.dayController.isWin)
        {
            Winbox.Setup().Show();
        }    
        else
        {
            playerContain.coinController.InitState(playerContain.dayController.GetBill);
            CardItemBox.Setup(playerContain, playerContain.itemController).Show();
    
        }    
 
    }    

    private void HandleBtnAds()
    {
  
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowVideoReward(
                   actionReward: () =>
                   {
                       Close();
                  
                       playerContain.coinController.coin = 0;
                       CardItemBox.Setup(playerContain, playerContain.itemController).Show();
                   },
                   actionNotLoadedVideo: () =>
                   {
                       GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp_UI
                        (btnAds.transform,
                        btnAds.transform.position,
                        "No video at the moment!",
                        Color.white,
                        isSpawnItemPlayer: true
                        );
                   },
                   actionClose: null,
                   ActionWatchVideo.WinBox_Claim_Coin,
                   UseProfile.CurrentLevel.ToString());
    }    

    private void HandleHome()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GamePlayController.Instance.playerContain.cardController.SaveDataHome();
        Initiate.Fade(SceneName.HOME_SCENE, Color.black, 2f);
    }    
}
