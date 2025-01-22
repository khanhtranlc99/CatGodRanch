using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SumCoinBar : MonoBehaviour
{
    public TMP_Text tmp;
    public Transform postIn;
    public Transform postOut;
    public int sumCoin = 50;
    public ItemInGameVfx itemInGameVfx;

   
    public IEnumerator HandleMoveIn()
    {
        sumCoin = 0;
        tmp.text = sumCoin + "<sprite name=\"Coin\">";
        yield  return transform.DOMove(postIn.position,0.7f).WaitForCompletion();
    }
    

    public void HandShowCoin(int coin)
    {
      
        sumCoin -= coin;
        tmp.text = sumCoin + "<sprite name=\"Coin\">";
        if (sumCoin <= 0)
        {
            tmp.text = "";
        }
    }

    public IEnumerator SpawnSumCoin()
    {
        tmp.text = 0 + "<sprite name=\"Coin\">";
        var temp = SimplePool2.Spawn(itemInGameVfx);
        temp.transform.position = new Vector3(tmp.transform.position.x, tmp.transform.position.y , tmp.transform.position.z);
        yield return temp.Init(sumCoin, GamePlayController.Instance.playerContain.coinController.tvCoin.transform);
      
        yield return   transform.DOMove(postOut.position, 0.7f).WaitForCompletion();
    }

}
