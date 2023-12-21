using System.Collections;
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
    private UiManager uiManager;
    [SerializeField] private PL_Position_PositionManager positionManager;
    [SerializeField] private GameObject _damageToPlayer;

    private int _damageReduced;
    [HideInInspector] public List<int> characterHP;
    private List<int> characterArmor;
    private List<int> classArmor;
    [HideInInspector] public StatsData currentAttackedPlayer;
    public int index { get; private set; } = 0;


    private void Awake()
    {
       DamageManagementInitialization();
       uiManager = GameObject.FindObjectOfType<UiManager>();
    }

    public void TakeDamage(int indexCharacter, int damage)
    {
        _damageReduced = damage - characterArmor[indexCharacter] - classArmor[indexCharacter];

        if (positionManager.CharacterStats()[0].HP - _damageReduced <= 0)
        {
            positionManager.CharacterStats()[0].HP = 0;
            OnCharacterDeath();
        }
        else
        {
            positionManager.CharacterStats()[0].HP -= _damageReduced;
            currentAttackedPlayer = positionManager.CharacterStats()[0];
            _damageToPlayer.SetActive(true);
            StartCoroutine(Desactivate());           
        }
    }

    private IEnumerator Desactivate()
    {
        yield return new WaitForSeconds(0.25f);
        _damageToPlayer.SetActive(false);  
    }

    public void OnCharacterDeath()
    {
        if (index == 2)
        {
            endGameMenu.SetActive(true);
            if(endGameMenu.activeSelf)
                endGameMenuManager.OnGameOverCheck(false);
        }
        else
        {
            //characterArmor.RemoveAt(index);
            //classArmor.RemoveAt(index);
            positionManager.CharacterStatsValue()[positionManager.CharacterStatsValue().FindIndex(dropdown => dropdown.value == 1)].value = 0;
            positionManager.CharacterStatsValue()[positionManager.CharacterStatsValue().FindIndex(dropdown => dropdown.value == 2)].value = 1;
            positionManager.CharacterStatsValue()[positionManager.CharacterStatsValue().FindIndex(dropdown => dropdown.value == 3)].value = 2;
            positionManager.CharacterStatsValue()[positionManager.CharacterStatsValue().FindIndex(dropdown => dropdown.value == 0)].value = 3;
            index++;

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

    private void Update()
    {
        uiManager.SetHealth();
    }
}
