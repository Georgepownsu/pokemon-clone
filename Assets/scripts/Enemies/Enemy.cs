using UnityEngine;

public class Enemy
{
    Enemyscript _base;
    int level;

    public Enemy(Enemyscript pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
    }

    public int Attack
    {
        get
        {
            return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5;
        }
    }
    public int Defense
    {
        get
        {
            return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5;
        }
    }
    public int Speed
    {
        get
        {
            return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5;
        }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((_base.SpDefense * level) / 100f) + 5; }
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10; }
    }
}
