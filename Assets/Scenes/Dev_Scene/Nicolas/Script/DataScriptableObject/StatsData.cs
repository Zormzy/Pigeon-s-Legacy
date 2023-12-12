using UnityEngine;

[CreateAssetMenu(fileName = "StatsData", menuName = "Game/Data")]
public class StatsData : ScriptableObject
{
    public string name;
    public string description;
    public GameObject gameObjectmodel;
    public int MaxHP;
    public int HP;
    public int Armor;
    public int Speed;
    public int Damage;
}
