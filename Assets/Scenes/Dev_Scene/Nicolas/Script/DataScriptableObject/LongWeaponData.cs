using UnityEngine;

[CreateAssetMenu(fileName = "LongWeaponData", menuName = "Game/LongWeaponData")]
public class LongWeaponData : ScriptableObject
{
    public string description;
    public GameObject gameObjectmodel;

    public int bonusDamage;

}
