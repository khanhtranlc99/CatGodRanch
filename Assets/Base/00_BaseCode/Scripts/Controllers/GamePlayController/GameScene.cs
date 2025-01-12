using System.Collections;
 
using UnityEngine;
 
using UnityEngine.UI;
using DG.Tweening;
 

public class GameScene : BaseScene
{
 
    [SerializeField] private Text tvLevel;
    [SerializeField] private Button settinBtn;
    [SerializeField] private Transform canvas;
    [SerializeField] private Button resetBtn;
    public Button seeThrowBtn;
    public GameObject topParent;
    public Transform postTop;
    public void Init(PlayerContain playerContainParam )
    {
        tvLevel.text = "Level " + UseProfile.CurrentLevel;
        resetBtn.onClick.AddListener(HandleReset);
        seeThrowBtn.onClick.AddListener(delegate { HandleSeeThrowBtn(); });
        if(UseProfile.CurrentLevel != 1)
        {
            StartCoroutine(HandleShowTop());
        }
    }
    private void HandleReset()
    {


        Initiate.Fade("GamePlay", Color.black, 2f);
    }

    public IEnumerator HandleShowTop()
    {
        yield return topParent.transform.DOMove(postTop.transform.position, 1).WaitForCompletion();

    }    
    public void HandleOffButton()
    {
        resetBtn.gameObject.SetActive(false);
        settinBtn.gameObject.SetActive(false); 
    }
    public void HandleOnButton()
    {
        resetBtn.gameObject.SetActive(true);
        settinBtn.gameObject.SetActive(true);
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
