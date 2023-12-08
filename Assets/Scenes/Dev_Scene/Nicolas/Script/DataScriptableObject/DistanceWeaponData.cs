using UnityEngine;

[CreateAssetMenu(fileName = "DistanceWeaponData", menuName = "Game/DistanceWeaponData")]
public class DistanceWeaponData : ScriptableObject
{

    public string description;
    public GameObject gameObjectmodel;

    public int bonusDamage;

}