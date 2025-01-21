using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : Singleton<HomeController>
{
    public HomeScene homeScene;
    public AnimalsHomeController animalsHomeController;
    public GameObject tutHome;
    public AudioClip dogCall;


    private void Start()
    {
        homeScene.Init();
        animalsHomeController.Init();
        if( UseProfile.CurrentLevel == 2 )
        {
            if (UseProfile.Coin > 0)
            {
                tutHome.SetActive(true);
                GameController.Instance.musicManager.PlayOneShot(dogCall);
            }
         
        }
        if (UseProfile.CurrentLevel == 3)
        {
            if(UseProfile.Coin >= 800)
            {
                tutHome.SetActive(true);
                GameController.Instance.musicManager.PlayOneShot(dogCall);
            }
  
        }
        if (UseProfile.CurrentLevel == 5)
        {
            if (UseProfile.Coin >= 800)
            {
                tutHome.SetActive(true);
                GameController.Instance.musicManager.PlayOneShot(dogCall);
            }

        }
        if (UseProfile.CurrentLevel == 10)
        {
            if (UseProfile.Coin >= 800)
            {
                tutHome.SetActive(true);
                GameController.Instance.musicManager.PlayOneShot(dogCall);
            }

        }
    }

}
