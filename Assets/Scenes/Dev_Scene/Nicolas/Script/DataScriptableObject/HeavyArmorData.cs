using UnityEngine;

[CreateAssetMenu(fileName = "HeavyArmorData", menuName = "Game/HeavyArmorData")]
public class HeavyArmorData : ScriptableObject
{
    public string description;
    public GameObject gameObjectmodel;

    public int bonusArmor;

}
