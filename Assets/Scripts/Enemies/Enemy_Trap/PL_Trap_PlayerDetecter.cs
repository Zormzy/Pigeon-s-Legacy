using UnityEngine;

public class PL_Trap_PlayerDetecter : MonoBehaviour
{
    [SerializeField] private PL_Trap_Scriptable trapScriptable;
    [SerializeField] private ParticleSystem trapParticle;
    private DamageManagement damageManagement;
    private float baseCooldown;
    private float cooldown = 0;
    private int damage;
    private bool difused;
    private Transform transformTrap;

    private void Awake()
    {
        baseCooldown = trapScriptable.cooldown;
        damage = trapScriptable.damage;
        difused = trapScriptable.difused;
        transformTrap = transform;
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
            ParticleSystem greenParticle = Instantiate(trapParticle, transformTrap);
            Destroy(greenParticle, 1);
            print("Trap attack player");
        }
    }

    public void DifuseTrap()
    {
        difused = true;
    }
}
