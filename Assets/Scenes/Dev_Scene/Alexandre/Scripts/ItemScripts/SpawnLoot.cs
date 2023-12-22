using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField] private List<GameObject> loot = new List<GameObject>();
    [SerializeField] [Range(0,49)] private int minNumber = 1;
    [SerializeField] [Range(1,50)] private int maxNumber = 2;
    [SerializeField] private Transform spawnPoint;
    private bool hasBeenCollected = false;
    private GameObject player;
    private Transform playerTransform;

    [SerializeField] public bool spawnLoot = true;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
    }
    private void OnValidate()
    {
        if (minNumber > maxNumber)
            maxNumber = minNumber + 1;
    }
    void Update()
    {
        if (spawnLoot && !hasBeenCollected)
        {
            spawnLoot = false;
            Loot();
        }
    }
    private void Loot()
    {
        hasBeenCollected = true;
        int number = Random.Range(minNumber, maxNumber);
        StartCoroutine(CreateLoot(number));
    }

    IEnumerator CreateLoot(int number)
    {
        for (int i = 0; i <number; i++)
        {
            GameObject tempLoot = Instantiate(loot[Random.Range(0, loot.Count)], playerTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
