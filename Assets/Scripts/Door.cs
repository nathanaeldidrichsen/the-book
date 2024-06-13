using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Animator anim;
    [SerializeField] private bool isLocked;
    public string requiredKey ="";
    private bool isOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Open()
    {
        if (anim != null && isLocked == false)
        {
            anim.SetTrigger("open");
            isOpen = true;
        }
    }

    public void Close()
    {
        if (anim != null)
        {
            anim.SetTrigger("close");
            isOpen = false;
        }
    }

    public override void Interact()
    {

        if(isLocked && Inventory.Instance.inventory.ContainsKey(requiredKey))
        {

isLocked = false;
        }
        

        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
