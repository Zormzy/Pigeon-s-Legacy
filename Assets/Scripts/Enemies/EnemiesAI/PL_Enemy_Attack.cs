using System.Collections;
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
    [SerializeField] private SpriteRenderer hitFeedback;

    [Header("Varibales")]
    public bool _isAttacking;
    private int _enemyAttackDamage;
    private float _enemyHitPoints;
    private int _enemyArmorPoints;
    private float _attackTimer;
    private float _attackTimerCount;
    private PL_Enemy_Collision enemyCollision;
    private PL_Enemy_EnemySpawner spawner;
    private AudioSource audioSource;
    [SerializeField] private AudioClip catDeath;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        PL_Enemy_Attack_Initialization();
    }

    private void Update()
    {
        if (enemyCollision.IsPlayerInFront())
            OnEnemyAttack();
        else if (_attackTimerCount != 0)
            _attackTimerCount = 0;

        healthBarEnnemy.value = _enemyHitPoints;
    }

    public void OnEnemyAttack()
    {
        if (_attackTimerCount >= _attackTimer)
        {
            _damageManagement.TakeDamage(0, _enemyAttackDamage);
            _attackTimerCount = 0;
        }
        else
            _attackTimerCount += Time.deltaTime;
    }


    public void OnTakeDamage(float damage)
    {
        if (_enemyHitPoints - (damage - _enemyArmorPoints) <= 0)
            OnEnemyDeath();
        else
        {
            _enemyHitPoints -= ((damage - _enemyArmorPoints));
        }
        StartCoroutine(HitFeedback());

    }

    private void OnEnemyDeath()
    {
        audioSource.clip = catDeath;
        audioSource.Play();
        gameObject.SetActive(false);
        spawner.EnemySelectPosition(spawner.Enemies.IndexOf(gameObject));
        _enemyHitPoints = _enemyStats.HP;
        print("enemy dead");
        gameObject.SetActive(true);
        healthBarEnnemy.value = 11;
    }

    private void PL_Enemy_Attack_Initialization()
    {
        _isAttacking = false;
        _enemyAttackDamage = _enemyStats.Damage;
        _enemyHitPoints = _enemyStats.HP;
        _enemyArmorPoints = _enemyStats.Armor;
        _attackTimer = 2;
        _attackTimerCount = 0f;
        _player = GameObject.FindGameObjectWithTag("Player");
        _damageManagement = _player.GetComponent<DamageManagement>();
        healthBarEnnemy.maxValue = _enemyStats.HP;
        healthBarEnnemy.value = _enemyStats.HP;
        enemyCollision = GetComponent<PL_Enemy_Collision>();
        spawner = GetComponentInParent<PL_Enemy_EnemySpawner>();
    }

    private IEnumerator HitFeedback()
    {
        hitFeedback.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        hitFeedback.color = Color.white;
    }
}
