using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalsLoading : MonoBehaviour
{
    public List<AnimLoading> lsAnimalsLoading;
    public SpriteRenderer aura;
    public ParticleSystem vfxStar;
    public SpriteRenderer titler;
    public CanvasGroup canvasGroup;

    
    public IEnumerator Init()
    {
       yield return  titler.transform.DOScale(Vector3.one, 0.5f).WaitForCompletion();
        yield return StartCoroutine(Main());
    }
    IEnumerator Main()
    {
        Sequence sequence = DOTween.Sequence();
        foreach(var item in lsAnimalsLoading)
        {
            sequence.Join(item.Move);
        }
        yield return sequence.WaitForCompletion();
        vfxStar.Play();
        aura.transform.DOScale(Vector3.one, 0.5f);
        yield return canvasGroup.DOFade(1,0.7f).WaitForCompletion();

    }
    private void Update()
    {
        aura.transform.localEulerAngles += new Vector3(0, 0, -0.1f)/**Time.deltaTime*/;
    }

}
