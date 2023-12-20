using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class PL_Enemy_EnemySpawner : MonoBehaviour
{
    [SerializeField] private PL_Enemy_EnemySpawnPosition EnemyPosition;
    [HideInInspector] public List<GameObject> Enemies;
    private List<Transform> transformEnemies = new List<Transform>();
    private List<Vector3> positionSelected = new List<Vector3>();
    private int previousBoxIndex;

    private void Awake()
    {
        Enemies = GetAllChilds(transform);
        //Enemies.Remove(transform.gameObject);
        print(Enemies.Count);
        for (int i = 0; i < Enemies.Count; i++)
        {
            print(Enemies[i].name);
            transformEnemies.Add(Enemies[i].transform);
            positionSelected.Add(EnemyPosition.enemyPositions[i]);
            EnemySelectPosition(i);
        }
    }

    List<GameObject> GetAllChilds(Transform t)
    {
        List<GameObject> ts = new List<GameObject>();

        foreach (Transform tc in t)
        {
            ts.Add(tc.gameObject);
        }

        return ts;
    }

    public void EnemySelectPosition(int j)
    {
        previousBoxIndex = EnemyPosition.enemyPositions.IndexOf(positionSelected[j]);

        for (int i = 0; i < EnemyPosition.caseOccuppied.Count; i++)
        {
            if (!EnemyPosition.caseOccuppied[i])
            {
                positionSelected[j] = EnemyPosition.enemyPositions[i];
                EnemyPosition.caseOccuppied[previousBoxIndex] = false;
                EnemyPosition.caseOccuppied[i] = true;
                transformEnemies[j].position = positionSelected[j];
                print("position found");
                break;
            }
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < EnemyPosition.caseOccuppied.Count; i++)
        {
            EnemyPosition.caseOccuppied[i] = false;
        }
    }
}
