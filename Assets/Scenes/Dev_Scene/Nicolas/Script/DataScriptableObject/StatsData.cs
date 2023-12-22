using UnityEngine;

[CreateAssetMenu(fileName = "StatsData", menuName = "Game/Data")]
public class StatsData : ScriptableObject
{
    public string name;
    public string description;
    public GameObject gameObjectmodel;
    public float MaxHP;
    public float HP;
    public float Armor;
    public float Speed;
    public float Damage;
}
