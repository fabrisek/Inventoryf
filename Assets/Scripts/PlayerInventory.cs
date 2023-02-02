
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory; // inventaire du joueur

    private void Start()
    {
        //inventory.ClearInventory();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            inventory.AddItem(collision.GetComponent<ItemObject>().ItemRef);
            Destroy(collision.gameObject);
        }
    }
}