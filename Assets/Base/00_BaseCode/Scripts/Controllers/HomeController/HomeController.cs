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
        if(!UseProfile.WasBoughtUnlimitTime)
        {
            UseProfile.WasBoughtUnlimitTime = true;
            tutHome.SetActive(true);
        }
    }

}
