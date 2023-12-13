using System.Collections.Generic;
using UnityEngine;

public class DoctorClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private HealthKitData healthKitData;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject player;
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private DamageManagement damageManagement;

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
            cooldowns[2] -= Time.deltaTime;
        }
    }

    public override void Skill2()
    {
        if (cooldowns[2] <= 0)
        {
            if (damageManagement.currentAttackedPlayer.HP + healthKitData.regenHP >= damageManagement.currentAttackedPlayer.MaxHP)
            {
                print("damage higher");
                damageManagement.currentAttackedPlayer.HP = 15;
                uiManager.SetHealth();
            }
            else if (damageManagement.currentAttackedPlayer.HP > 0)
            {
                print("heal");
                //si on a le medkit
                damageManagement.currentAttackedPlayer.HP += healthKitData.regenHP;
                uiManager.SetHealth();
                //Destroy(target.gameObject);
                // use medkit
            }

            cooldowns[2] = cooldowns[3];
        }
    }
}
