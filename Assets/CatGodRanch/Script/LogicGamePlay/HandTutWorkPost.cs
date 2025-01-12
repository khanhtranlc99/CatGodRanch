using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandTutWorkPost : MonoBehaviour
{
    public Transform post_1;
    public Transform post_2;
    public Transform hand;
   
    public void Init()
    {
        Move();
    }
    private void Move()
    {
        hand.transform.DOMove(post_1.position, 0.5f).OnComplete(delegate
        {
            hand.transform.DOMove(post_2.position, 0.5f).OnComplete(delegate
            {
                Move();
            });
        });
    }
    private void OnDestroy()
    {
        hand.transform.DOKill();
    }
}
