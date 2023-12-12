using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public StatsData statsData;
    public int curHealth = 0;
    public int maxHealth;
    
    void Start()
    {
        maxHealth = statsData.MaxHP;
        curHealth = maxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
}


