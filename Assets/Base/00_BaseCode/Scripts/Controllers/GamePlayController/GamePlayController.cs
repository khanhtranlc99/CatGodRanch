using Crystal;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateGame
{
    Loading = 0,
    Playing = 1,
    Win = 2,
    Lose = 3,
    Pause = 4
}

public class GamePlayController : Singleton<GamePlayController>
{
    public StateGame stateGame;
    public PlayerContain playerContain;
    public GameScene gameScene;
    public ItemInGameVfx itemInGameVfx;
    public TutorialFunController tutGamePlay;
    public TutorialFunController tutCard;
    public AudioClip coinsfx;
    protected override void OnAwake()
    {
        //  GameController.Instance.currentScene = SceneType.GamePlay;

     
        Init();

    }

    public void Init()
    {
        SimplePool2.ClearPool();
        SimplePool2.Preload(itemInGameVfx.gameObject,10);
        playerContain.Init();
        gameScene.Init(playerContain);   
        tutGamePlay.Init();
        tutGamePlay.StartTut();
        tutCard.Init();
        if(!UseProfile.FirstLoading)
        {
            UseProfile.TutGamePlayCard_Step_1 = false;
            UseProfile.TutGamePlayCard_Step_2 = false;
            UseProfile.TutGamePlayCard_Step_3 = false;
            UseProfile.TutGamePlay_Step_3 = false;
        }
    }


    public IEnumerator SpawnItemInGameVfx(int paramCoin, Vector3 post)
    {
        var temp =  SimplePool2.Spawn(itemInGameVfx);
        temp.transform.position = new Vector3(post.x, post.y+1, post.z);
        GameController.Instance.musicManager.PlayOneShot(coinsfx);
        yield return StartCoroutine(temp.Init(paramCoin));
     

     
    }
    public IEnumerator SpawnItemInGameVfx(int paramCoin, Vector3 post, bool item)
    {
        var temp = SimplePool2.Spawn(itemInGameVfx);
        temp.transform.position = new Vector3(post.x, post.y + 1, post.z);
        GameController.Instance.musicManager.PlayOneShot(coinsfx);
        yield return StartCoroutine(temp.Init(paramCoin, item));



    }

}
