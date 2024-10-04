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
    [SerializeField] private DayController dayController;
    [SerializeField] private CoinController coinController;

    public void Init(LevelData levelData)
    {
    
     
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {
     
    }
}
