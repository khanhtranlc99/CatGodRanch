using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class RhinoAnim : AnimTutBase
{
    public GameObject rhino;
    public GameObject randomObj;

    public Vector3 rhino_post;
    public Vector3 random_post;

    public GameObject post;
    public GameObject post_new;
 

    public List<Sprite> lsSprite;

    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        rhino_post = rhino.transform.position;
        random_post = randomObj.transform.position;
        StartCoroutine(HandleShowTut());
    }
    private IEnumerator HandleShowTut()
    {
        yield return new WaitForSeconds(1);
        yield return rhino.transform.DOMove(post.transform.position, 1).WaitForCompletion();

        randomObj.GetComponent<Image>().sprite = lsSprite[Random.Range(0, lsSprite.Count)];

        rhino.transform.localScale = new Vector3(-1, 1, 1);
        randomObj.transform.localScale = new Vector3(-1, 1, 1);
        Sequence sequence = DOTween.Sequence();       
        sequence.Join(randomObj.transform.DOMove(post_new.transform.position, 1.5f));
        sequence.Join(rhino.transform.DOMove(rhino_post, 1.8f));
        yield return sequence.WaitForCompletion();
        rhino.transform.localScale = new Vector3(1, 1, 1);
        randomObj.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(1);

        randomObj.transform.position = random_post;


        yield return new WaitForSeconds(1);

        Init();
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
}