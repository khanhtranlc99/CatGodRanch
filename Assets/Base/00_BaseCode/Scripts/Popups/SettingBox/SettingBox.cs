using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine.U2D;
public class SettingBox : BaseBox
{
    #region instance
    public static SettingBox instance;
    public static SettingBox Setup(bool isOffButton, bool isSaveBox = false, Action actionOpenBoxSave = null)
    {
        if (instance == null)
        {
            instance = Instantiate(Resources.Load<SettingBox>(PathPrefabs.SETTING_BOX));
            instance.Init();
        }

        instance.InitState(isOffButton);
        return instance;
    }
    #endregion
    #region Var

    [SerializeField] private Button btnClose;
  

    [SerializeField] private Button btnVibration;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnSound;

  
    public Image imgMusic;
    public Image imgVibration;
    public Image imgSound;

    public Sprite musicOn;
    public Sprite musicOff;
    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite vibraOn;
    public Sprite vibraOff;

    public GameObject musicOnObj;
    public GameObject musicOffObj;
    public GameObject soundOnObj;
    public GameObject soundOffObj;
    public GameObject vibraOnObj;
    public GameObject vibraOffObj;



    public Button btnHome;
    public Button btnRestart;

    public bool isGameplay;

    public Vector3 postOn = new Vector3(90, -36, 0);
    public Vector3 postOff = new Vector3(35, -36, 0);

    #endregion
    private void Init()
    {
        btnClose.onClick.AddListener(delegate { OnClickButtonClose(); }); 
        btnVibration.onClick.AddListener(delegate { OnClickBtnVibration(); });
        btnMusic.onClick.AddListener(delegate { OnClickBtnMusic(); });
        btnSound.onClick.AddListener(delegate { OnClickBtnSound(); });
        
  
        btnHome.onClick.AddListener(delegate { HandleBtnHome(); });
        btnRestart.onClick.AddListener(delegate { HandleBtnRestart(); });
       
  
    }
  
    private void InitState(bool param)
    {
        isGameplay = param;
        if (param)
        {
            
            btnHome.gameObject.SetActive(true);
            btnRestart.gameObject.SetActive(true);
       
        }    
        else
        {
         
            btnHome.gameObject.SetActive(false);
            btnRestart.gameObject.SetActive(false);
        }    
    
        SetUpBtn();
       
    }

    public void OffBtn()
    {
        btnHome.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
    }    
    private void SetUpBtn()
    {
        if (UseProfile.OnVibration)
        {
            imgVibration.sprite = vibraOn;
            vibraOnObj.SetActive(true);
            vibraOffObj.SetActive(false);
        }
        else
        {
            imgVibration.sprite = vibraOff;
            vibraOnObj.SetActive(false);
            vibraOffObj.SetActive(true);
        }

        if (UseProfile.OnMusic)
        {
            imgMusic.sprite = musicOn;
            musicOnObj.SetActive(true);
            musicOffObj.SetActive(false);
        }
        else
        {
            imgMusic.sprite = musicOff;
            musicOnObj.SetActive(false);
            musicOffObj.SetActive(true);
        }

        if (UseProfile.OnSound)
        {
            imgSound.sprite = soundOn;
            soundOnObj.SetActive(true);
            soundOffObj.SetActive(false);
        }
        else
        {
            imgSound.sprite = soundOff;
            soundOnObj.SetActive(false);
            soundOffObj.SetActive(true);
        }
      
    }

  
    private void OnClickBtnVibration()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (UseProfile.OnVibration)
        {
            UseProfile.OnVibration = false;
        }
        else
        {
            UseProfile.OnVibration = true;
        }
        SetUpBtn();
    }

    private void OnClickBtnMusic()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (UseProfile.OnMusic)
        {
            UseProfile.OnMusic = false;
        }
        else
        {
            UseProfile.OnMusic = true;
        }
        SetUpBtn();
    }
    private void OnClickBtnSound()
    {
        GameController.Instance.musicManager.PlayClickSound();
        if (UseProfile.OnSound)
        {
            UseProfile.OnSound = false;
        }
        else
        {
            UseProfile.OnSound = true;
        }
        SetUpBtn();
    }


    private void OnClickButtonClose()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowInterstitial(false, actionIniterClose: () => { Next(); }, actionWatchLog: "BtnCloseSettingBox");

        void Next()
        {
            if(isGameplay)
            {
      
             
            }    
        
            Close();

        }
  
    }


    public void HandleBtnHome()
    {

        GameController.Instance.admobAds.ShowInterstitial(false, actionIniterClose: () => { Next(); }, actionWatchLog: "BtnBackHomeSettingBox");

        void Next()
        {

            Close();
            Initiate.Fade("HomeScene", Color.black, 1.5f);

        }
        GameController.Instance.musicManager.PlayClickSound();
        //BackHomeBox.Setup(TypeBackHOme.BackHome).Show();



    }
    public void HandleBtnRestart()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowInterstitial(false, actionIniterClose: () => { Next(); }, actionWatchLog: "Restart");
        void Next()
        {
            Close();
            Initiate.Fade("GamePlay", Color.black, 1.5f);
        }
        //Close();
        //GameController.Instance.musicManager.PlayClickSound();
        //BackHomeBox.Setup(TypeBackHOme.ResetLevel).Show();


    }
    private void OnClickRestorePurchase()
    {
        GameController.Instance.iapController.RestorePurchases();
    }    

}
