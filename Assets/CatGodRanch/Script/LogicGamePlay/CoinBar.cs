using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinBar : MonoBehaviour
{
    public Text tvCoin;
    public Button btnShop;
    public void Init()
    {
        tvCoin.text = UseProfile.Coin.ToString();
        EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.CHANGE_COIN, HandleChangeCoin);

    }
    private void HandleChangeCoin(object param)
    {
        tvCoin.text = UseProfile.Coin.ToString();
    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.CHANGE_COIN, HandleChangeCoin);
    }
}
