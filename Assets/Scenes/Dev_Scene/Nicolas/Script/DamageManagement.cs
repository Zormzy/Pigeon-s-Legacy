using System.Collections.Generic;
using UnityEngine;

public class DamageManagement : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private List<ClassData> classStats;
    [SerializeField] private UiManager uiManager;

    private int _damageReduced;
    private List<int> characterHP;
    private List<int> characterArmor;
    private List<int> classArmor;


    private void Awake()
    {
       // DamageManagementInitialization();
    }


    public void TakeDamage(int indexCharacter, int damage, int indexClass)
    {
        _damageReduced = damage - characterArmor[indexCharacter] - classArmor[indexClass];

        if (characterHP[indexCharacter] - _damageReduced <= 0)
        {
            OnCharacterDeath();
        }
        else
        {
            characterHP[indexCharacter] -= _damageReduced;
            uiManager.SetHealth();
        }
    }

    public void OnCharacterDeath()
    {
        Debug.Log("Character Death");
    }

    public void DamageManagementInitialization()
    {

        characterHP = new List<int>();
        characterArmor = new List<int>();

        foreach (var _character in characterStats)
        {
            characterHP.Add(_character.HP);
            characterArmor.Add(_character.Armor);
        }
        foreach (ClassData _class in classStats)
        {
            classArmor.Add(_class.classArmor);
        }
    }
}
