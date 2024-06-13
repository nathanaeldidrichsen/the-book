using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Manages inventory, keeps several component references, and any other future control of the game itself you may need*/

public class Inventory : MonoBehaviour
{
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    private static Inventory instance;
    // Singleton instantiation
    public static Inventory Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Inventory>();
            return instance;
        }
    }



void Start()
{
}
    // Use this for initialization
    public void AddInventoryItem(string name, Sprite image)
    {
        inventory.Add(name, image);
        Debug.Log("Added " + name + " to your inventory");
        if (image != null)
        {
            // hud.SetInventoryImage(inventory[name]);
        }
    }

    public void RemoveInventoryItem(string name)
    {
        inventory.Remove(name);
        // hud.SetInventoryImage(hud.blankUI);
    }

    public void ClearInventory()
    {   
        inventory.Clear();
        // hud.SetInventoryImage(hud.blankUI);
    }

}
