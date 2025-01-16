using MoreMountains.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class HomeScene : BaseScene
{

    public Button btnSetting;
    public Button btnPlay;
    public Button btnCard;
    public Button btnDic;
    public Text tvLevel;
    public CoinBar coinBar;





    public void Init()
    {
        btnSetting.onClick.AddListener(delegate { GameController.Instance.musicManager.PlayClickSound(); OnSettingClick(); });
        btnPlay.onClick.AddListener(delegate { GameController.Instance.musicManager.PlayClickSound(); HandlePlay(); });
        tvLevel.text = "LEVEL " + UseProfile.CurrentLevel.ToString();
        btnCard.onClick.AddListener(HandleShowCardBox);
        btnDic.onClick.AddListener(delegate { DictionaryBox.Setup().Show(); });
        coinBar.Init();
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {

    }
    private void OnSettingClick()
    {
        SettingBox.Setup(false).Show();
    }
    private void HandlePlay()
    {
        Initiate.Fade("GamePlay", Color.black, 2f);
    }

    private void HandleShowCardBox()
    {
        RandomCardBox.Setup(HomeController.Instance.animalsHomeController.animalsData).Show();
    }

 
  
}
