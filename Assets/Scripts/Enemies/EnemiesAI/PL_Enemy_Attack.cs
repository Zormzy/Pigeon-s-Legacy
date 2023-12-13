using UnityEngine;
using UnityEngine.UI;

public class PL_Enemy_Attack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnnemyStatsData _enemyStats;
    private GameObject _player;
    private DamageManagement _damageManagement;

    [Header("Character1")]
    [SerializeField] private Slider healthBarEnnemy;
    [SerializeField] private Image healthFill;

    [Header("Varibales")]
    public bool _isAttacking;
    private int _enemyAttackDamage;
    private int _enemyHitPoints;
    private int _enemyArmorPoints;
    private float _attackTimer;
    private float _attackTimerCount;

    private void Awake()
    {
        PL_Enemy_Attack_Initialization();
        healthBarEnnemy.maxValue = _enemyStats.HP;
        healthBarEnnemy.value = _enemyStats.HP;
    }

    private void Update()
    {
        if (_isAttacking)
            OnEnemyAttack();
        else if (_attackTimerCount != 0)
            _attackTimerCount = 0;
    }

    public void OnEnemyAttack()
    {
        if (_attackTimerCount >= _attackTimer)
        {
            _damageManagement.TakeDamage(Random.Range(0, 1), _enemyAttackDamage);
            _attackTimerCount = 0;
        }
        else
            _attackTimerCount += Time.deltaTime;
    }

    public void OnTakeDamage(int damage)
    {
        if (_enemyHitPoints - (damage - _enemyArmorPoints) <= 0)
            OnEnemyDeath();
        else
            _enemyHitPoints -= ((damage - _enemyArmorPoints));
            healthBarEnnemy.value -= ((damage - _enemyArmorPoints));

    }

    private void OnEnemyDeath()
    {
        gameObject.SetActive(false);
    }

    private void PL_Enemy_Attack_Initialization()
    {
        _isAttacking = false;
        _enemyAttackDamage = _enemyStats.Damage;
        _enemyHitPoints = _enemyStats.HP;
        _enemyArmorPoints = _enemyStats.Armor;
        _attackTimer = 1f;
        _attackTimerCount = 0f;
        _player = GameObject.FindGameObjectWithTag("Player");
        _damageManagement = _player.GetComponent<DamageManagement>();
    }
}
