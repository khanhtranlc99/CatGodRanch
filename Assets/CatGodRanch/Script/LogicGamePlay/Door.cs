using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{
    public Transform post_close;
    public Transform post_open;

    public Tween closeDoor
    {
        get
        {
            return transform.DOMoveX(post_close.transform.position.x, 1);
        }
    }
    public Tween openDoor
    {
        get
        {
            return transform.DOMoveX(post_open.transform.position.x, 1);
        }
    }

   
}
