using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class CoinController : MonoBehaviour
{
    public int coin;
    public TMP_Text tvCoin;
    public Image coinBar;
    public int targetCoin;
    public void Init(int paramTargetCoin)
    {
        coin = 0;
        targetCoin = paramTargetCoin;
        tvCoin.text = coin + "/" + targetCoin + "<sprite name=\"Coin\">";
        coinBar.fillAmount = 0;
    }
    public void InitState(int paramTargetCoin)
    {
        targetCoin = paramTargetCoin;
        tvCoin.text = coin + "/" + targetCoin + "<sprite name=\"Coin\">";
        coinBar.fillAmount = 0;
    }    

    public void HandlePlusCoin(int coinParam)
    {
        coin += coinParam;
        tvCoin.text = coin + "/" + targetCoin + "<sprite name=\"Coin\">";
        if (coinBar.fillAmount < 1)
        {
            var temp = (float)coin / targetCoin;
            coinBar.DOFillAmount(temp, 0.35f);
        }   
        else
        {
            coinBar.fillAmount = 1;
        }    
    }


}
