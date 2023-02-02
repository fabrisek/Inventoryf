using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public Transform container; // référence au parent de tous les éléments d'inventaire
    public float radius; // rayon du cercle d'inventaire
    public Inventory inventory; // référence à l'inventaire
    List<GameObject> inventoryUI = new List<GameObject>();
    Item selectedItem;
    public GameObject selection;
    void Start()
    {
        GenerateButtons();
    }
    void Update()
    {
        RefreshDisplayUIItem();
        // Get mouse or controller input
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        //Vector2 joystickDirection = InputSystem.GetDevice<Gamepad>().leftStick.ReadValue();
        Vector2 inputDirection = Vector2.zero;
        if (mousePosition != Vector2.zero)
        {
            inputDirection = mousePosition;
        }
        inputDirection = inputDirection.normalized * radius;

        /*else if (joystickDirection.magnitude > 0.1f)
        {
            inputDirection = joystickDirection;
        }*/
        // Move cursor within circle
        if (inputDirection.magnitude > radius)
            inputDirection = inputDirection * radius;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        selection.transform.position = center;

       // selection.transform.position = new Vector3(inputDirection.x, inputDirection.y, selection.transform.position.z);
        // Find closest item
        float closestDistance = float.MaxValue;
        for (int i = 0; i < inventoryUI.Count; i++)
        {
            float distance = Vector3.Distance(inputDirection, inventoryUI[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                selectedItem = inventory.items[i];
            }
        }
        Debug.Log(selectedItem, selectedItem);
    }

    private void GenerateButtons()
    {
        foreach(var itemUi in inventoryUI)
        {
            Destroy(itemUi);
        }
        inventoryUI.Clear();
        // pour chaque élément d'inventaire
        for (int i = 0; i < inventory.items.Count; i++)
        { 
            Item item = inventory.items[i];
            if(item == null)
            {
                continue;
            }
            // créer un objet UI pour représenter l'élément
            GameObject itemUI = new GameObject(item.name);
            inventoryUI.Add(itemUI);
            Image image = itemUI.AddComponent<Image>();
            image.sprite = item.itemSprite;
            // positionner l'objet UI sur un cercle autour du centre de l'interface utilisateur
            float angle = i * (360f / inventory.items.Count);
            float x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            itemUI.transform.SetParent(container);
            itemUI.transform.localPosition = new Vector3(x, y, 0);
        }
    }
     private void RefreshDisplayUIItem()
    {
        if (inventory.items.Count != inventoryUI.Count)
        {
            GenerateButtons();
            return;
        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            var gameObjectItemUI = inventoryUI[i];
            var item = inventory.items[i];
            Image image = gameObjectItemUI.GetComponent<Image>();
            image.sprite = item.itemSprite;
        }
    }
}
