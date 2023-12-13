using UnityEngine;

public class DoctorClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private HealthKitData healthKitData;
    [SerializeField] private Transform _playerTransform;

    private float[] cooldowns = new float[4];
    private int _damage;
    private RaycastHit _raycastHit;
    private void Awake()
    {
        cooldowns[0] = cooldowns[1] = classData.cooldownAttack;
        cooldowns[2] = cooldowns[3] = classData.cooldownSkill;
    }
    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 1))
            if (_raycastHit.transform.CompareTag("Enemy") && cooldowns[0] <= 0)
            {
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
                cooldowns[0] = cooldowns[1];
                print("doctor attack");
            }
    }

    private void Update()
    {
        if (cooldowns[0] > 0)
        {
            cooldowns[0] -= Time.deltaTime;
        }

        if (cooldowns[2] > 0)
        {
            cooldowns[3] -= Time.deltaTime;
        }
    }

    public override void Skill2()
    {  
        statsData.MaxHP = 15;
        if (cooldowns[2] <= 0)
        {
            if (statsData.HP > 0)
            {
                statsData.HP += healthKitData.regenHP;
                //Destroy(target.gameObject);
                // use medkit
            }

            if (statsData.HP + healthKitData.regenHP > statsData.MaxHP)
            {
                statsData.HP = 15;
            }
            cooldowns[2] = cooldowns[3];
        }
    }
}
