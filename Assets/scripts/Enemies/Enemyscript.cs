using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemy/Create New Enemies")]
public class Enemyscript : ScriptableObject
{
    #region SERIALIZED FIELDS
    [SerializeField] public string Name { get; set; }

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite Frontsprite;
    [SerializeField] Sprite Backsprite;

    [SerializeField] EnemyType type1;
    [SerializeField] EnemyType type2;

    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    #endregion




    #region FIELDS / PROPERTIES
    public string Description
    {
        get { return description; }
    }
    public EnemyType Type1
    {
        get { return type1; }
    }
    public EnemyType Type2
    {
        get { return type2; }
    }
    public int MaxHP
    {
        get { return maxHP; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    #endregion
}

public enum EnemyType
{
    None,
    Fire,
    Water,
    Wind,
    Earth,
}