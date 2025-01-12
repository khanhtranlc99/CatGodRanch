using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CoyoteAnim : AnimTutBase
{
 
    public Image icon;
    public GameObject coin;
    public GameObject xCondition;
    public GameObject boxChat;
    public Vector3 post_Coin;

   
    public override void Init()
    { 
        post_Coin = coin.transform.position;
        StartCoroutine(HandleEffect());
    }
    public IEnumerator HandleEffect()
    {
        xCondition.gameObject.SetActive(false);
        boxChat.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        boxChat.gameObject.SetActive(false);

        yield return icon.transform.DOJump(icon.transform.position, 1, 1, 0.5f).WaitForCompletion();
        coin.GetComponent<TMP_Text>().text = "-2" + "<sprite name=\"Coin\">";
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = post_Coin;

        yield return new WaitForSeconds(1);
        boxChat.gameObject.SetActive(true);
        xCondition.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        boxChat.gameObject.SetActive(false);
        yield return icon.transform.DOJump(icon.transform.position, 1, 1, 0.5f).WaitForCompletion();
        coin.GetComponent<TMP_Text>().text = "+2" + "<sprite name=\"Coin\">";
        coin.gameObject.SetActive(true);
        yield return coin.transform.DOMove(new Vector3(post_Coin.x, post_Coin.y + 0.5f, post_Coin.z), 1).WaitForCompletion();
        coin.gameObject.SetActive(false);
        coin.gameObject.transform.position = post_Coin;

        yield return new WaitForSeconds(1.5f);
            Init();
      
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }
}