using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/ Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public Sprite Icon;
    [TextArea(4, 4)]
    public int ID;
    public int MaxStackSize;
    public string DisplayName;
    public string Description;

}
