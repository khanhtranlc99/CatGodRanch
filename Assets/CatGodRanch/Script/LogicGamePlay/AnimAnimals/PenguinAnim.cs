using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using DG.Tweening;

public class PenguinAnim : AnimTutBase
{
    public GameObject penguin;
    public TMP_Text tmpTime;
    int day;
    public Transform postMove;
    public Vector3 firstPost;
    public GameObject boxChat;
    public Image icon;
    public List<Sprite> lsSprite;


  
    public override void Init()
    {
        boxChat.gameObject.SetActive(false);
        firstPost = penguin.transform.position;
        day = 3;
        tmpTime.text = day + "<sprite name=\"Time\">";
        tmpTime.gameObject.SetActive(true);
        StartCoroutine(HandleEffect());
    }

    public IEnumerator HandleEffect()
    {
        penguin.transform.DOKill();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(penguin.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Join(penguin.transform.DOJump(penguin.transform.position, 1, 1, 0.5f));
        sequence.Append(penguin.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(penguin.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.2f));
        sequence.Append(penguin.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f));
        sequence.Append(penguin.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f));
        yield return sequence.WaitForCompletion();
        day -= 1;
        tmpTime.text = day.ToString() + "<sprite name=\"Time\">";
        yield return new WaitForSeconds(0.5f);

        if (day > 0)
        {
            StartCoroutine(HandleEffect());
        }
        else
        {
            tmpTime.text = "";
            tmpTime.gameObject.SetActive(false);
            yield return penguin.transform.DOMove(postMove.transform.position, 0.5f).WaitForCompletion();
            penguin.transform.localScale = new Vector3 (-1, 1, 1);
            yield return penguin.transform.DOMove(firstPost, 0.5f).WaitForCompletion();
            penguin.transform.localScale = new Vector3(1, 1, 1);
            var temp = Random.Range(0, lsSprite.Count);
            icon.sprite = lsSprite[temp];
            boxChat.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            Init();
        }


    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

}
