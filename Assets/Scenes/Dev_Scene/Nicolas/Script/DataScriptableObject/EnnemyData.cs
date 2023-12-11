using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyStatsData", menuName = "Game/EnnemyData")]
public class EnnemyStatsData : ScriptableObject
{
    public string name;
    public string description;
    public GameObject gameObjectmodel;
    public int HP;
    public int Damage;

}
