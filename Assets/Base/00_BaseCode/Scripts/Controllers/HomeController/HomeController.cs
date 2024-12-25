using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : Singleton<HomeController>
{
    public HomeScene homeScene;
    public AnimalsHomeController animalsHomeController;
  

    private void Start()
    {
        homeScene.Init();
        animalsHomeController.Init();
    }

}
