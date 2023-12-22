using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PL_Position_PositionManager : MonoBehaviour
{
    [SerializeField] private List<StatsData> characterStats;
    [SerializeField] private List<StatsData> characterStatsOrdered = new List<StatsData>(){null, null, null, null};
    [SerializeField] private List<TMP_Dropdown> gestionDropdown;
    private bool changing = false;
    private int[] previousValues = new int[4];
    private int[] unchangedValue = new int[4];

    private void Awake()
    {
        for(int i = 0; i < gestionDropdown.Count; i++)
        {
            unchangedValue[i] = previousValues[i] = gestionDropdown[i].value = i;
        }
        //for (int i = 0; i < gestionDropdown.Count; i++)
        //{
        //    
        //    gestionDropdown[i].onValueChanged.AddListener(value => ChangeValue(value, index));
        //}
        
    }

    private void Update()
    {
        for (int i = 0; i < gestionDropdown.Count; i++)
        {
            if (gestionDropdown[i].value != previousValues[i])
            {
                previousValues[i] = gestionDropdown[i].value;
                ChangeValue(gestionDropdown[i].value, i);
            }
            characterStatsOrdered[gestionDropdown[i].value] = characterStats[i];
        }
    }

    private void ChangeValue(int arg0, int i)
    {
        //if (changing)
        //{
        //    changing = false;
        //    return;
        //}

        var previousValue = unchangedValue[i];
        var currentValue = gestionDropdown[i].value;

        EchangerValeurs(ref previousValue, ref currentValue);
        for (int j = 0; j < 4; j++)
        {
            if(gestionDropdown[j].value == previousValue)
            {
                gestionDropdown[j].value = currentValue;
            }
        }
        gestionDropdown[i].value = previousValue;


        for (int k = 0; k < gestionDropdown.Count; k++)
        {
            unchangedValue[k] = gestionDropdown[k].value;
        }
        //StatsData temp = characterStats[currentValue];
        //characterStats[currentValue] = characterStats[previousValue];
        //characterStats[previousValue] = temp;
        //changing = true;

    }

    void EchangerValeurs(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public List<TMP_Dropdown> CharacterStatsValue()
    {
        return gestionDropdown;
    }

    public List<StatsData> CharacterStats()
    {
        return characterStatsOrdered;
    }
}
