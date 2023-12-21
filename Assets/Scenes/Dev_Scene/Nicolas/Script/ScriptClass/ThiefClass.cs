using UnityEngine;

public class ThiefClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private DamageManagement damageManagement;
    private PL_Position_PositionManager positionManager;
    private Transform _playerTransform;
    private float[] cooldowns = new float[4];

    private int _damage;
    private RaycastHit _raycastHit;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        positionManager = GetComponentInParent<PL_Position_PositionManager>();
    }

    private void Awake()
    {
        cooldowns[0] = cooldowns[1] = classData.cooldownAttack;
        cooldowns[2] = cooldowns[3] = classData.cooldownSkill;
    }
    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 1) && damageManagement.index <= 1)
            if (_raycastHit.transform.CompareTag("Enemy") && cooldowns[0] <= 0)
            {
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
                cooldowns[0] = cooldowns[1];
                print("thief attack");
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

        Debug.DrawRay(_playerTransform.position, _playerTransform.forward, Color.red);
    }

    public override void Skill2()
    {
        foreach(var raycastHit in Physics.RaycastAll(_playerTransform.position, _playerTransform.forward))
        {
            if(raycastHit.transform.tag == "Trap" && cooldowns[2] <= 0)
            {
                cooldowns[2] = cooldowns[3];
                raycastHit.transform.gameObject.GetComponent<PL_Trap_PlayerDetecter>().DifuseTrap();
                print("trap difused");
                break;
            }
        }
    }
}
