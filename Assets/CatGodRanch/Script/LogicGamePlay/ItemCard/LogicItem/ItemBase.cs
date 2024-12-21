using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public enum ItemName
{
    Nest,
    Puddle,
    Sand,
    Grass,
    LiveStockLicense,
    DogTrainningLeash,
    GrowExpress,
    GoatHorn,
    NutritionalSupplement,
    GrowTalent,
    TribalTalent,
    CarnivoreTalent,
    MonneyBag,
    SheepPen
}
public abstract class ItemBase : MonoBehaviour
{
    public int count = 0;
    public ItemName itemName;
    public TMP_Text tvNum;
    //public Image icon;
    public abstract void Init();
    public abstract IEnumerator HandleEffectItemIEnumrator();
   
}
