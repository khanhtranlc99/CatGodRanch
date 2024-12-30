using System.Collections;
using System.Collections.Generic;
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
            Debug.LogError("id_Post_" + temp.id);
            Debug.LogError("tempAnimals" + lsCardRandom[rand].ToString());
            Debug.LogError("Rhino_name_" + tempAnimals.prefabAnimals.gameObject.name);
            SpwanAnimals(tempAnimals.prefabAnimals, temp);
        }
        yield return null;
    }

    public void SpwanAnimals(GameObject animalsBase, PostYardBase postYardBase)
    {

        var tempPost = postYardBase;
        if (tempPost != null)
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            temp.GetComponent<AnimalsBase>().coinPlus += 2;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
    
        }

    }
}
