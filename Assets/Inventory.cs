using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items; // liste d'items dans l'inventaire

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void ClearInventory()
    {
        items.Clear();
    }
}