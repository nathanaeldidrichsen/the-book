using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public string itemName;

    public override void Interact()
    {
        PickUp();
    }


public void PickUp()
{
SoundManager.Instance.PlayPickupSound();
Inventory.Instance.AddInventoryItem(itemName, null);

//Only for the flashlight
if(itemName == "flashlight")
{
    GameManager.Instance.firstPersonController.hasFlashlight = true;
}
Destroy(this.gameObject);

}

}
