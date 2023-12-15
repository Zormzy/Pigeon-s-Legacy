using UnityEngine;

public class EngineerClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private Transform _playerTransform;

    private int _damage;
    private RaycastHit _raycastHit;
    private float[] cooldowns = new float[4];
    private void Awake()
    {
        cooldowns[0] = cooldowns[1] = classData.cooldownAttack;
        cooldowns[2] = cooldowns[3] = classData.cooldownSkill;
    }
    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 2))
            if (_raycastHit.transform.CompareTag("Enemy") && cooldowns[0] <= 0)
            {
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
                cooldowns[0] = cooldowns[1];
                print("engineer attack");
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
        if(cooldowns[2] <= 0)
        {
            //skill 2
            cooldowns[2] = cooldowns[3];
        }
    }
}
