using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicKup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    public void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void CollectToInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.IsFull[i] == false)
            {
                inventory.IsFull[i] = true;
                Instantiate(slotButton, inventory.slots[i].transform);
                break;
            }
        }
    }


}
