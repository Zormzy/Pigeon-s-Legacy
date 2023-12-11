using UnityEngine;

public class WarriorClass : ClassesSkills
{

    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    private int damage;
    public override void Skill1(GameObject target)
    {
        damage = statsData.Damage + classData.classDamage;   
        //call Enemy function TakeDamage (damage)
    }

    public override void Skill2(GameObject target)
    {
        
    }
}
