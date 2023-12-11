using UnityEngine;

public class DoctorClass : ClassesSkills
{

    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private HealthKitData healthKitData;
    private int damage;
    public override void Skill1(GameObject target)
    {
        damage = statsData.Damage + classData.classDamage;
        //call Enemy function TakeDamage (damage)
    }

    public override void Skill2(GameObject target)
    {  
        statsData.MaxHP = 15;
        if (statsData.HP > 0)
        {
            statsData.HP += healthKitData.regenHP;
            Destroy(target.gameObject);
        }

        if (statsData.HP + healthKitData.regenHP > statsData.MaxHP)
        {
            statsData.HP = 15;
        } 
    }
}
