using UnityEngine;

[CreateAssetMenu(fileName = "MediumArmorData", menuName = "Game/MediumArmorData")]
public class MediumArmorData : ScriptableObject
{
    public string description;
    public GameObject gameObjectmodel;

    public int bonusArmor;

}
