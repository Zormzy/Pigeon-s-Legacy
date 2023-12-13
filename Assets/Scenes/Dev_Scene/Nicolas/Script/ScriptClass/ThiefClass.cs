using UnityEngine;

public class ThiefClass : ClassesSkills
{
    [Header("Components")]
    [SerializeField] private ClassData classData;
    [SerializeField] private StatsData statsData;
    [SerializeField] private Transform _playerTransform;

    private int _damage;
    private RaycastHit _raycastHit;

    public override void Skill1()
    {
        _damage = statsData.Damage + classData.classDamage;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _raycastHit, 1))
            if (_raycastHit.transform.CompareTag("Enemy"))
                _raycastHit.transform.GetComponent<PL_Enemy_Attack>().OnTakeDamage(_damage);
    }

    public override void Skill2()
    {

    }
}
