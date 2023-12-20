using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    public float PickupRadius = 1f;
    public InventoryItemData ItemData;
    private SphereCollider myCollider;
    [SerializeField] private OpenInventory menuManager;
    [SerializeField] private PL_Player_Interact playerInteract;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickupRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;
        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            menuManager.WarriorClicked();
            playerInteract.Key(true);
            Destroy(this.gameObject);
        }
    }
}
