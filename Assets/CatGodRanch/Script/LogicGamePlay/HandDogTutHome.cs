using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandDogTutHome : MonoBehaviour
{
    public Transform firstPost;
    public Transform secondPost;
    void Start()
    {
        Move();
    }
   
    private void Move()
    {
        this.transform.DOMove(firstPost.position, 0.5f).OnComplete(delegate
        {
            this.transform.DOMove(secondPost.position, 0.5f).OnComplete(delegate
            {
                Move();
            });
        });
    }

     
}
