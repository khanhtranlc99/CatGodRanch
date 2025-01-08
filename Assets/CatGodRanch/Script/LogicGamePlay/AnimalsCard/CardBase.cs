using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardRank
{
    Normal,
    Rare,
    SuperRare,
    Epic,
    Leagendary
}
public abstract class CardBase : MonoBehaviour
{
    public CardRank cardRank;
    public AnimalsDataProperty animalsDataProperty;
    public ItemDataProperty itemDataProperty;
    public AnimTutBase tutBase;
    

    public abstract void Init( );
    public abstract bool CanShow();
    public abstract void HandleAction();
}
