using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : Singleton<HomeController>
{
    public HomeScene homeScene;
    public AnimalsHomeController animalsHomeController;
    public GameObject tutHome;

    private void Start()
    {
        homeScene.Init();
        animalsHomeController.Init();
        if( UseProfile.CurrentLevel == 2 )
        {
            if (UseProfile.CurrentLevel >= 0)
            {
                tutHome.SetActive(true);
            }
         
        }
        if (UseProfile.CurrentLevel == 3)
        {
            if(UseProfile.CurrentLevel >= 800)
            {
                tutHome.SetActive(true);
            }
  
        }
    }

}
