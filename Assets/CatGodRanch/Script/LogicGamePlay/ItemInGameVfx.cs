using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemInGameVfx : MonoBehaviour
{
    public TMP_Text tvNumb;
    public SpriteRenderer spriteRenderer;
    public IEnumerator Init(int param)
    {
        tvNumb.DOFade(1, 0.1f);
        tvNumb.text =   param + "<sprite name=\"Coin\">";
        spriteRenderer.sprite = null;
        this.transform.localScale = Vector3.zero;
        yield return this.transform.DOScale(new Vector3(1, 1, 1), 0.2f).WaitForCompletion();
        yield return this.transform.DOMoveY(this.transform.position.y + 0.3f, 0.2f).WaitForCompletion();
        yield return tvNumb.DOFade(0, 0.2f).WaitForCompletion();
        SimplePool2.Despawn(this.gameObject);
    }

   
   
    private void OnDisable()
    {
        this.transform.DOKill();
        tvNumb.DOKill();
    }
    private void OnDestroy()
    {
        this.transform.DOKill();
        tvNumb.DOKill();
    }
}
