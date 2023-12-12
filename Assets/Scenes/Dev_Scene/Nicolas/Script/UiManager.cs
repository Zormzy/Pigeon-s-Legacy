using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField] public DamageManagement damageManagement;

    [Header("ScriptableObject")]
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private List<ClassData> classStats;

    [Header ("Character1")]
    [SerializeField] private Slider healthBar_1;
    [SerializeField] private Image healthFill_1;
    [Header("Character2")]
    [SerializeField] private Slider healthBar_2;
    [SerializeField] private Image healthFill_2;
    [Header("Character3")]
    [SerializeField] private Slider healthBar_3;
    [SerializeField] private Image healthFill_3;
    [Header("Character4")]
    [SerializeField] private Slider healthBar_4;
    [SerializeField] private Image healthFill_4;

    private List<int> characterHP;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInitialHealth(int maxHealth1, int maxHealth2, int maxHealth3, int maxHealth4)
    {
        healthBar_1.maxValue = maxHealth1;
        healthBar_1.value = maxHealth1;

        healthBar_2.maxValue = maxHealth2;
        healthBar_2.value = maxHealth2;

        healthBar_3.maxValue = maxHealth3;
        healthBar_3.value = maxHealth3;

        healthBar_4.maxValue = maxHealth4;
        healthBar_4.value = maxHealth4;
    }

    private void SetHealth()
    {

    }
}
