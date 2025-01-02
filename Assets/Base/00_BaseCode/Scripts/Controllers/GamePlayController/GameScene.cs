using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;
using UnityEngine.Events;

public class GameScene : BaseScene
{
 
    [SerializeField] private Text tvLevel;
    [SerializeField] private Button settinBtn;
    [SerializeField] private Transform canvas;
    [SerializeField] private Button resetBtn;
    public Button seeThrowBtn;

    public void Init(PlayerContain playerContainParam )
    {
        tvLevel.text = "Level " + UseProfile.CurrentLevel;
        resetBtn.onClick.AddListener(HandleReset);
        seeThrowBtn.onClick.AddListener(delegate { HandleSeeThrowBtn(); });

    }
    private void HandleReset()
    {


        Initiate.Fade("GamePlay", Color.black, 2f);
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {
     
    }
    private void HandleSeeThrowBtn()
    {
        CardAnimalsBox.instance.HandleOn();
        seeThrowBtn.gameObject.SetActive(false);
    }
}
