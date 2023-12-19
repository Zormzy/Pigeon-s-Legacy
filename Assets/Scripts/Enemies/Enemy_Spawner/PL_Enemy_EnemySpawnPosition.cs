using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPosition", menuName = "Game/Enemy")]
public class PL_Enemy_EnemySpawnPosition : ScriptableObject
{
    public List<Vector3> enemyPositions = new List<Vector3>();
    public List<bool> caseOccuppied;
}
