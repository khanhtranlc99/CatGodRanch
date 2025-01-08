using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum AnimalsType
{
    Hoofed,
    Bird,
    Carnivore,
}
public enum AnimalsName
{
    Egg,
    Chicken,
    Turkey,
    Duck,
    Goose,
    Dove,
    Lamp,
    Goat,
    Sheep,
    Alpaca,
    Calf,
    WaterBuffalo,
    Cow,
    Pig,
    Dog,
    Wolf,
    Hyena,
    Fox,
    Tiger,
    Pigeon,
    Eagle,
    Ostrich,
    Penguin,
    Magpie,
    Crow,
    Horse,
    Gazelle,
    SikaDeer,
    ReinDeer,
    MuskOx,
    Rhino,
    Coyote,
    Skunk,
    Badger,
    MaleLion,
    FemaleLion,
    Cheetah,
    Crocodile,
    Rooster,

}


public abstract class AnimalsBase : MonoBehaviour
{
    public CardRank animalsRank;
    public AnimalsType animalsType;
    public AnimalsName animalsName;
    public Sprite spriteAnimalsType;
    public SpriteRenderer spriteRender;
    public int coinPlus;
    public PostYardBase postYardBase;
    public GameObject canvas;
    public List<AnimalsBase> lsAnimalsProtect;
    public AnimalsBase huntAnimal;
    public List<PostYardBase> lsPostRange;


    public void SetUpPlus()
    {
        AnimScale();
        InitRange();
    }
    public void AnimScale()
    {
        spriteRender.transform.DOKill();
        spriteRender.transform.localEulerAngles = Vector3.zero;
        var ranScaleOut = Random.RandomRange(0.3f, 0.35f);
        var ranScaleIn = Random.RandomRange(0.3f, 0.35f);
        spriteRender.transform.DOScale(new Vector3(1.1f, 1, 1), ranScaleOut).OnComplete(delegate
        {
            spriteRender.transform.DOScale(new Vector3(1, 1, 1), ranScaleIn).OnComplete(delegate
            {
                AnimScale();
            });
        });

    }    

    public void AnimRotateInMove()
    {
        spriteRender.transform.DOKill();
        spriteRender.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.1f).OnComplete(delegate
        {
            spriteRender.transform.DOLocalRotate(new Vector3(0, 0, -10f), 0.1f).OnComplete(delegate
            {
                AnimRotateInMove();
            });
        });
    }

      
    public abstract void Init();
    public abstract void InitState();
    public abstract IEnumerator HandleEffect();
  
    public virtual void HandleActionDie()
    {
        GamePlayController.Instance.playerContain.cardController.HandleRemoveCurrentAnimals(animalsName);
        if (postYardBase.animalsBase != null)
        {
            postYardBase.animalsBase = null;
        }
        if (postYardBase != null)
        {
            postYardBase = null;
        }
     
        huntAnimal = null;
        lsAnimalsProtect.Clear();
        //GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
        SimplePool2.Despawn(this.gameObject);
        spriteRender.transform.DOKill();
    }    
    public virtual IEnumerator HandleActionMove(Vector3 paramPost)
    {
        AnimRotateInMove();
        if (canvas != null)
        {
            canvas.SetActive(false);
        }   
       yield return transform.DOMove(paramPost, 1.25f).OnComplete(delegate {

           if (canvas != null)
           {
               canvas.SetActive(true);
           }

       }).WaitForCompletion();
    }
    public virtual IEnumerator  HandleClaimCoin()
    {
        spriteRender.transform.DOKill();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(spriteRender.transform.DOScale(new Vector3(1.4f, 1, 1), 0.15f));
        sequence.Append(spriteRender.transform.DOScale(new Vector3(0.8f, 1, 1), 0.15f));
        sequence.Append(spriteRender.transform.DOScale(new Vector3(1, 1, 1), 0.15f));
        yield return sequence.WaitForCompletion();
        AnimScale();
        yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(coinPlus, transform.position));
    
    }

    public virtual IEnumerator HandleActionProtect()
    {      
        yield return null;
    }

    public virtual void InitRange()
    {
        if(lsPostRange.Count > 0)
        {
            lsPostRange.Clear();
        }
        foreach(var item in postYardBase.lsNearYard)
        {
            lsPostRange.Add(item);
        }
    }

    public void OnDestroy()
    {
        spriteRender.transform.DOKill();
        transform.DOKill();
       
    }
}
