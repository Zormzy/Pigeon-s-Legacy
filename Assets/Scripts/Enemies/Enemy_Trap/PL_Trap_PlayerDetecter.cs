using UnityEngine;

public class PL_Trap_PlayerDetecter : MonoBehaviour
{
    [SerializeField] private PL_Trap_Scriptable trapScriptable;
    private DamageManagement damageManagement;
    private float baseCooldown;
    private float cooldown;
    private int damage;
    private bool difused;

    private void Awake()
    {
        baseCooldown = cooldown = trapScriptable.cooldown;
        damage = trapScriptable.damage;
        difused = trapScriptable.difused;
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && cooldown <= 0 && !difused)
        {
            damageManagement = other.GetComponent<DamageManagement>();
            damageManagement.TakeDamage(Random.Range(0, 1), damage);
            cooldown = baseCooldown;
            print("Trap attack player : ");
        }
    }

    public void DifuseTrap()
    {
        difused = true;
    }
}
