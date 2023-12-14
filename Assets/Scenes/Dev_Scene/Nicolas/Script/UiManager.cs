using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private DamageManagement damageManagement;


    [Header("ScriptableObject")]
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private List<ClassData> classStats;

    [Header("Character1")]
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

    [Header("HealthBars")]
    private List<Slider> healthBars;
    [SerializeField] private List<TextMeshProUGUI> charactersHp;

    private void Awake()
    {
        healthBars = new List<Slider>() {healthBar_1, healthBar_2, healthBar_3, healthBar_4 };
        SetInitialHealth(characterStats[0].MaxHP);
    }

    public void SetInitialHealth(int maxHealth)
    {
        foreach (Slider slider in healthBars)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }
    }

    public void SetHealth()
    {
        for (int i = 0; i < characterStats.Count; i++)
        {
            healthBars[i].value = damageManagement.characterHP[i];
            //charactersHp[i].text = healthBars[i].value.ToString() + " / " + healthBars[i].maxValue.ToString();
        }
    }
}
