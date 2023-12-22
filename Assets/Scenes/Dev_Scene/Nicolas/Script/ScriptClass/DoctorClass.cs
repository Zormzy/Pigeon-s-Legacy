using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoctorClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private HealthKitData healthKitData;
    [SerializeField] private PL_Position_PositionManager positionManager;
    private Transform _playerTransform;
    private GameObject player;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private DamageManagement damageManagement;

    private float[] cooldowns = new float[4];
    private float _damage;
    private RaycastHit _raycastHit;
    private AudioSource audioSource;
    private float[] HP = new float[4] { 0, 0, 0, 0};

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = player.transform;
    }

    private void Awake()
    {
        cooldowns[1] = classData.cooldownAttack - classData.classSpeed / 10;
        cooldowns[3] = classData.cooldownSkill - classData.classSpeed / 10;
    }
    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 1) && positionManager.CharacterStats()[0].HP != 0)
            if (_raycastHit.transform.CompareTag("Enemy") && cooldowns[0] <= 0)
            {
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
                cooldowns[0] = cooldowns[1];
                print("doctor attack");
                audioSource.Play();
            }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < positionManager.CharacterStats().Count; i++)
        {
            HP[i] = positionManager.CharacterStats()[i].HP;
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
        print("index : " + positionManager.CharacterStats().FindIndex(data => data.HP == HP.Min() && data.HP != 0));
        StatsData healCharacter = positionManager.CharacterStats()[positionManager.CharacterStats().FindIndex(data => data.HP == HP.Min() && data.HP != 0)];
        if (cooldowns[2] <= 0)
        {
            if (damageManagement.currentAttackedPlayer.HP + healthKitData.regenHP >= damageManagement.currentAttackedPlayer.MaxHP)
            {
                print("damage higher");
                healCharacter.HP = 15;
                uiManager.SetHealth();
            }
            else if (damageManagement.currentAttackedPlayer.HP > 0)
            {
                print("heal");
                //si on a le medkit
                healCharacter.HP += healthKitData.regenHP;
                uiManager.SetHealth();
                //Destroy(target.gameObject);
                // use medkit
            }

            cooldowns[2] = cooldowns[3];
        }
    }
}
