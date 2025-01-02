using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class WordCanvasController : MonoBehaviour
{
    public GameObject postWordCanvas;
   public WordCanvas wordCanvas;
    public List<int> lsPostRight;
    public List<int> lsPostLeft;
    

    public void HandleShow(PostYardBase postYardBase)
    {
        postWordCanvas.gameObject.SetActive(true);
        postWordCanvas.transform.position = postYardBase.vectorWordPost;
        wordCanvas.InitState(postYardBase.animalsBase);
    }
    public void HandleOff()
    {
        postWordCanvas.gameObject.SetActive(false);
    }
}
