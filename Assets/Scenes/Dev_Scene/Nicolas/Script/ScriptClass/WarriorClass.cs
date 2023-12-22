using UnityEngine;

public class WarriorClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private DamageManagement damageManagement;
    private Transform _playerTransform;
    private PL_Position_PositionManager positionManager;

    private float _damage;
    private RaycastHit _raycastHit;
    private float[] cooldowns = new float[4];
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        positionManager = GameObject.FindAnyObjectByType<PL_Position_PositionManager>();
    }

    private void Awake()
    {
        cooldowns[1] = classData.cooldownAttack - classData.classSpeed / 10;
        cooldowns[3] = classData.cooldownSkill - classData.classSpeed / 10;
    }
    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 1) && positionManager.CharacterStats()[positionManager.CharacterStats().IndexOf(positionManager.CharacterStatsInordered()[0])].HP > 0)
            if (_raycastHit.transform.CompareTag("Enemy") && cooldowns[0] <= 0)
            {
                cooldowns[0] = cooldowns[1];
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
                print("warrior attack");
                audioSource.Play();
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
