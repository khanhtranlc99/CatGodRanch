using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx.Triggers;
using UnityEngine;

public class Rhino : AnimalsBase
{
    public PostYardBase EmtyPostYard
    {
        get
        {
            foreach(var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if(item.animalsBase == null)
                {
                    return item;
                }
            }
            return null;
        }
    }
    public List<AnimalsName> lsCardRandom  ;
    public bool CanHandleEffect
    {
        get
        {
            if (huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
    public override void Init()
    {
        SetUpPlus();
    }
    public override void InitState()
    {

    }
    public override void InitRange()
    {
        
    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {
            yield return StartCoroutine(HandleAddRandomHoofed());
        }
        yield return null;
    }

    private IEnumerator HandleAddRandomHoofed()
    {

        var temp = EmtyPostYard;
        if(temp != null)
        {
            var rand = Random.Range(0, lsCardRandom.Count);
            var tempAnimals = GamePlayController.Instance.playerContain.cardController.GetCardName(lsCardRandom[rand]);
        
            yield return StartCoroutine(SpwanAnimals(tempAnimals.prefabAnimals, temp));
             

        }
        yield return null;
    }

    public IEnumerator SpwanAnimals(GameObject animalsBase, PostYardBase postYardBase1)
    {

        
        var tranformPost = GamePlayController.Instance.playerContain.animalController.penguinController.post.position;
        AnimRotateInMove();
        yield return this.transform.DOMove(tranformPost, 1.5f).WaitForCompletion();
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tranformPost;
            postYardBase1.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = postYardBase1;
            temp.GetComponent<AnimalsBase>().coinPlus += 2;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());

        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        temp.transform.localScale = new Vector3(-temp.transform.localScale.x, temp.transform.localScale.y, temp.transform.localScale.z);
        temp.GetComponent<AnimalsBase>().AnimRotateInMove();
        Sequence sequence = DOTween.Sequence();
        sequence.Join(temp.transform.DOMove(postYardBase1.transform.position, 2));
        sequence.Join(this.transform.DOMove(postYardBase1.transform.position, 2.5f));
       
        yield return sequence.WaitForCompletion();
        temp.GetComponent<AnimalsBase>().AnimScale();
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        yield return this.transform.DOMove(postYardBase.transform.position, 1).WaitForCompletion();
        AnimScale();
     
        temp.transform.localScale = new Vector3(Mathf.Abs(temp.transform.localScale.x), temp.transform.localScale.y, temp.transform.localScale.z);
    }
}
