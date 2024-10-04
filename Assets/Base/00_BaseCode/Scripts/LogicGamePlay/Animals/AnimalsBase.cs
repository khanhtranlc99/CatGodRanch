using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalsRank
{
    Normal,
    Rare,
    SuperRare,
    Epic,
    Leagendary
}
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
    Tiger
}


public abstract class AnimalsBase : MonoBehaviour
{
    public AnimalsRank animalsRank;
    public AnimalsType animalsType;
    public AnimalsName animalsName;
    public SpriteRenderer spriteRender;
    public int coinPlus;
       
    public abstract void Init();
    public abstract void InitState();
    public abstract void HandleEffect();
    public abstract void HandleClaimCoin();
    public abstract void HandleActionDie();
    public abstract void HandleActionMove();
}
