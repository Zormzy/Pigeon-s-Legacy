using UnityEngine;

[CreateAssetMenu(fileName = "ShortWeaponData", menuName = "Game/ShortWeaponData")]
public class ShortWeaponData : ScriptableObject
{

    public string description;
    public GameObject gameObjectmodel;

    public int bonusDamage;

}