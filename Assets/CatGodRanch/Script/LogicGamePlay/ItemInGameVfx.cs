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
        yield return this.transform.DOMoveY(this.transform.position.y + 0.3f, 0.5f).WaitForCompletion();
        yield return this.transform.DOMove(GamePlayController.Instance.playerContain.animalController.sumCoinBar.tmp.transform.position, 0.2f).SetDelay(0.3f).SetEase(Ease.InOutQuad).WaitForCompletion();
        GamePlayController.Instance.playerContain.animalController.sumCoinBar.HandShowCoin(param);
        SimplePool2.Despawn(this.gameObject);
    }
    public IEnumerator Init(int param, bool item)
    {
        tvNumb.DOFade(1, 0.1f);
        tvNumb.text = param + "<sprite name=\"Coin\">";
        spriteRenderer.sprite = null;
        this.transform.localScale = Vector3.zero;
        yield return this.transform.DOScale(new Vector3(1, 1, 1), 0.2f).WaitForCompletion();
        yield return this.transform.DOMoveY(this.transform.position.y + 0.3f, 0.2f).WaitForCompletion();
        yield return this.transform.DOMove(GamePlayController.Instance.playerContain.coinController.tvCoin.transform.position, 0.2f).SetDelay(0.3f).SetEase(Ease.InOutQuad).WaitForCompletion();
        GamePlayController.Instance.playerContain.coinController.HandlePlusCoin(param);
        SimplePool2.Despawn(this.gameObject);
    }

    public IEnumerator Init(int param, Transform move)
    {
        tvNumb.DOFade(1, 0.1f);
        tvNumb.text = param + "<sprite name=\"Coin\">";
        spriteRenderer.sprite = null;
        this.transform.localScale = Vector3.zero;
        yield return this.transform.DOScale(new Vector3(1, 1, 1), 0.2f).WaitForCompletion();
        yield return this.transform.DOMoveY(this.transform.position.y + 0.3f, 0.2f).WaitForCompletion();
        yield return this.transform.DOMove(move.position, 0.75f).SetEase(Ease.InOutBack).WaitForCompletion();
        GamePlayController.Instance.playerContain.coinController.HandlePlusCoin(param);
        SimplePool2.Despawn(this.gameObject);
        yield return new WaitForSeconds(0.5f);
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
