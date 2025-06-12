using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicKup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    private GameObject image;

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
                image = Instantiate(slotButton, inventory.slots[i].transform);
                Drop.ItemIconka.Add(image);
                break;
            }
        }
    }


}
