using UnityEngine;

public class PL_Enemy_PlayerDetecter : MonoBehaviour
{
    private bool playerDetected = false;
    private Transform transformTrigger;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        transformTrigger = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerDetected = true;
    }
    private void OnTriggerStay(Collider other)
    {
        print("player detected");
        playerDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetected = false;
    }

    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}
