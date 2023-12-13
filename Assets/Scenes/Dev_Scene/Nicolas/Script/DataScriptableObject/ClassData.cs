using UnityEngine;

[CreateAssetMenu(fileName = "ClassData", menuName = "Game/ClassData")]
public class ClassData : ScriptableObject
{
    public string description;
    public GameObject gameObjectmodel;

    public int classArmor;
    public int classSpeed;
    public int classDamage;
    public float cooldownAttack;
    public float cooldownSkill;

}