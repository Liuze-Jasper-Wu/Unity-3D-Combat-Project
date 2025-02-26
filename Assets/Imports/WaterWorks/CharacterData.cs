using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Create New Character")]
public class CharacterData : ScriptableObject
{
    public float gold;
    public float silver;
    public float copper;
    public int health;
    public int level;
    public float exp;
    public int strength;
}
