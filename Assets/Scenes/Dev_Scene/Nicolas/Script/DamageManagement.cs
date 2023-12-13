using System.Collections.Generic;
using UnityEngine;

public class DamageManagement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private EndMenu endGameMenuManager;

    [Header("ScriptableObject")]
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private List<ClassData> classStats;
    [SerializeField] private UiManager uiManager;

    private int _damageReduced;
    public List<int> characterHP;
    private List<int> characterArmor;
    private List<int> classArmor;
    public StatsData currentAttackedPlayer;


    private void Awake()
    {
       DamageManagementInitialization();
    }

    private void Update()
    {
        characterHP[4 - characterArmor.Count] = characterStats[4 - characterArmor.Count].HP;
    }

    public void TakeDamage(int indexCharacter, int damage)
    {
        _damageReduced = damage - characterArmor[indexCharacter] - classArmor[indexCharacter];

        if (characterStats[4 - characterArmor.Count].HP - _damageReduced <= 0)
            OnCharacterDeath();
        else
        {
            characterStats[4 - characterArmor.Count].HP -= _damageReduced;
            currentAttackedPlayer = characterStats[4 - characterArmor.Count];
            uiManager.SetHealth();
        }
    }

    public void OnCharacterDeath()
    {
        if (characterArmor.Count == 2)
        {
            endGameMenuManager.OnGameOverCheck(false);
            endGameMenu.SetActive(true);
        }
        else
        {
            characterArmor.RemoveAt(0);
            classArmor.RemoveAt(0);
        }
    }

    public void DamageManagementInitialization()
    {
        characterHP = new List<int>();
        characterArmor = new List<int>();
        classArmor = new List<int>();
        for(int i = 0; i < 4; i++)
        {
            characterStats[i].HP = characterStats[i].MaxHP;
        }

        foreach (StatsData _character in characterStats)
        {
            characterHP.Add(_character.HP);
            characterArmor.Add(_character.Armor);
        }
        foreach (ClassData _class in classStats)
        {
            classArmor.Add(_class.classArmor);
        }
        currentAttackedPlayer = characterStats[0];
    }
}
