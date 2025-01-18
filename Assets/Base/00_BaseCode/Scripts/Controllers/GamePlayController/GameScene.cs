using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class GameScene : BaseScene
{
 
    [SerializeField] private Text tvLevel;
    [SerializeField] private Button settinBtn;
    [SerializeField] private Transform canvas;
    [SerializeField] private Button houseBtn;
    public Button seeThrowBtn;
    public GameObject topParent;
    public Transform postTop;
    public Transform postRight;
    public List<GameObject> lsbutton;
    public CameraScale cameraScale;
    public Transform post_1;
    public Transform post_2;

    public void Init(PlayerContain playerContainParam)
    {
        tvLevel.text = "Level " + UseProfile.CurrentLevel;
        houseBtn.onClick.AddListener(HandleHouse);
        seeThrowBtn.onClick.AddListener(delegate { GameController.Instance.musicManager.PlayClickSound(); HandleSeeThrowBtn(); });
        settinBtn.onClick.AddListener(delegate { GameController.Instance.musicManager.PlayClickSound(); SettingBox.Setup(true).Show(); });
        cameraScale.Init();
        StartCoroutine(cameraScale.FixScreen(post_1.position, post_2.position, delegate { HandleUI(); }));
       
        void HandleUI()
        {
            if (UseProfile.CurrentLevel != 1)
            {
                StartCoroutine(HandleShowTop());
                StartCoroutine(HandleRight());
            }
        }
    }
    private void HandleHouse()
    {
        GameController.Instance.musicManager.PlayClickSound();
        StorehouseBox.Setup().Show();


    }

    public IEnumerator HandleShowTop()
    {
        yield return new WaitForEndOfFrame();
        yield return topParent.transform.DOMove(postTop.transform.position, 1).WaitForCompletion();

    }    
    private IEnumerator HandleRight()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < lsbutton.Count; i ++)
        {
             yield return lsbutton[i].transform.DOMoveX(postRight.transform.position.x, 0.5f).WaitForCompletion();
        }
    }    


    public void HandleOffButton()
    {
        houseBtn.gameObject.SetActive(false);
        settinBtn.gameObject.SetActive(false); 
    }
    public void HandleOnButton()
    {
        houseBtn.gameObject.SetActive(true);
        settinBtn.gameObject.SetActive(true);
    }

    public void HandleOnOnclickButton()
    {
        houseBtn.interactable = true;
        settinBtn.interactable = true;
    }
    public void HandleOffOnclickButton()
    {
        houseBtn.interactable = false;
        settinBtn.interactable = false;
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
