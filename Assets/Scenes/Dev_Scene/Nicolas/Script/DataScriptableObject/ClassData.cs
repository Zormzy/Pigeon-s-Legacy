using UnityEngine;

[CreateAssetMenu(fileName = "ClassData", menuName = "Game/ClassData")]
public class ClassData : ScriptableObject
{
    public string description;
    public GameObject gameObjectmodel;

    public float classArmor;
    public float classSpeed;
    public float classDamage;
    public float cooldownAttack;
    public float cooldownSkill;

}