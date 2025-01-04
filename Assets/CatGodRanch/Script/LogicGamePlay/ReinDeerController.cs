using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class ReinDeerController : MonoBehaviour
{
    public Transform postUp;
    public Transform postDown;
    public Transform postLeft;
    public Transform postRight;

    public Transform GetPost(Vector3 postDeer, Vector3 postTarget)
    {
        if(postDeer.y == postTarget.y)
        {
            if(postDeer.x < postTarget.x)
            {
                return postRight;
            }
            if (postDeer.x > postTarget.x)
            {
                return postLeft;
            }
        }
        if (postDeer.y < postTarget.y)
        {
            if (postDeer.x < postTarget.x)
            {
                return postRight;
            }
            if (postDeer.x > postTarget.x)
            {
                return postLeft;
            }
        }
        if (postDeer.y > postTarget.y)
        {
            return postDown;
        }

        return postUp;
    }
  
}
