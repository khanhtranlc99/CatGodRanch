using DG.Tweening;
using UnityEngine;

public class AnimLoading : MonoBehaviour
{
    public Transform post;
    public Tween Move
    {
        get
        {
            return transform.DOMove(post.position, 1).OnComplete(delegate { HandleTest(); });
        }
    }

    public void HandleTest()
    {
        transform.DOMoveY(post.position.y + Random.RandomRange(0.1f, 0.5f), 0.5f).OnComplete(delegate {
            transform.DOMoveY(post.position.y , 0.5f).OnComplete(delegate {

                HandleTest();
            });

        });

    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
}
