using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageManagement : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private List<StatsData> characterStats;

    private int _damageReduced;
    private List<int> characterHP;
    private List<int> characterArmor;

    private void Awake()
    {
        DamageManagementInitialization();
    }


    public void TakeDamage(int indexCharacter,int damage)
    { 
        _damageReduced = damage -  characterArmor[indexCharacter];

        if (characterHP[indexCharacter] - _damageReduced <= 0)
        {
            DestroyWhenDeath();
        }
        else
        {
            characterHP[indexCharacter] -= _damageReduced;
        }
    }


    public void DestroyWhenDeath()
    {
        Destroy(gameObject);        
    }


    private void DamageManagementInitialization()
    {
        characterHP = new List<int>();
        characterArmor = new List<int>();

        foreach (var character in characterStats)
        {
            characterHP.Add(character.HP);
            characterArmor.Add(character.Armor);
        }   
    }
}
