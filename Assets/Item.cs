using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName; // Nom de l'item
    public Sprite itemSprite; // Sprite de l'item
    public string itemDescription; // description de l'item
}