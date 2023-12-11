using UnityEngine;

[CreateAssetMenu(fileName = "HealthKitData", menuName = "Game/HealthKitData")]
public class HealthKitData : ScriptableObject
{

    public string description;
    public GameObject gameObjectmodel;

    public int regenHP;

}
