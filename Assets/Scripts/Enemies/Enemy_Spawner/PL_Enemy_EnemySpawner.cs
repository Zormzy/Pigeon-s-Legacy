using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class PL_Enemy_EnemySpawner : MonoBehaviour
{
    [SerializeField] private PL_Enemy_EnemySpawnPosition EnemyPosition;
    private Transform transformEnemy;
    private Vector3 positionSelected;
    private int previousBoxIndex;

    private void Awake()
    {
        for(int i = 0; i < EnemyPosition.caseOccuppied.Count; i++)
        {
            EnemyPosition.caseOccuppied[i] = false;
        }
        transformEnemy = transform;
        positionSelected = EnemyPosition.enemyPositions[Random.Range(0, EnemyPosition.enemyPositions.Count)];
        EnemySelectPosition();
    }

    public void EnemySelectPosition()
    {
        previousBoxIndex = EnemyPosition.enemyPositions.IndexOf(positionSelected);
        positionSelected = EnemyPosition.enemyPositions[Random.Range(0, EnemyPosition.enemyPositions.Count)];
        if (EnemyPosition.caseOccuppied[EnemyPosition.enemyPositions.IndexOf(positionSelected)])
        {
            EnemySelectPosition();
            print("position occupied");
        }
        else
        {
            print(EnemyPosition.enemyPositions.IndexOf(positionSelected));
            EnemyPosition.caseOccuppied[previousBoxIndex] = false;
            EnemyPosition.caseOccuppied[EnemyPosition.enemyPositions.IndexOf(positionSelected)] = true;
            transformEnemy.position = positionSelected;
        }
        
    }
}
