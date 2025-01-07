using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckController : MonoBehaviour
{
    public List<AnimalsBase> lsDuck ;
    public Transform postA;
    public Transform postB;
    public bool isRun;
    int countDuck;
    public void InitState()
    {
        isRun = false;
        if(lsDuck.Count > 0)
        {
            lsDuck.Clear();
        }   
    }
    public void HandleAddDuck(AnimalsBase duck)
    {
        if(!lsDuck.Contains(duck))
        {
            lsDuck.Add(duck);
        }     
    }

    public IEnumerator HandleEffectDuck()
    {
        if(!isRun)
        {
            
            isRun = true;
            countDuck = 0;
            foreach (var duck in lsDuck)
            {
                if (duck.gameObject.activeSelf)
                {
                    countDuck += 1;
                }
            }
            if(countDuck >= 3)
            {
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {
                        duck.AnimRotateInMove();
                    }
                }
                Sequence sequence = DOTween.Sequence();
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {
                        sequence.Join(duck.transform.DOMove(postB.position, 1.5f));
                    }
                }
                yield return sequence.WaitForCompletion();
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {
                        duck.transform.position = postA.position;
                    }
                }
                Sequence sequence2 = DOTween.Sequence();
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {
                        sequence2.Join(duck.transform.DOMove(duck.postYardBase.transform.position, 1.5f));
                    }
                }
                yield return sequence2.WaitForCompletion();
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {
                        duck.AnimScale();
                    }
                }
                foreach (var duck in lsDuck)
                {
                    if (duck.gameObject.activeSelf)
                    {                      
                        yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, duck.transform.position));
                       
                    }
                }
            }
            else
            {
                yield return null;
            }         
        }
        else
        {
            yield return null;
        }
     
    }

}
