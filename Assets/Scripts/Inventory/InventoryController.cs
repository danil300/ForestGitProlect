using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public int selectedIndex = 1;
    public GameObject ScrollControll;
    public GameObject PlaceToDrop;

    private int MaxSlots = 4;
    private Invnetory inventory;
    private GameObject DropedItem;
    private GameManager manager;

    public void Start()
    {
        inventory = GetComponent<Invnetory>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    public void Update()
    {
        Controll();
        Drop();
    }


    public void Controll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            selectedIndex = (selectedIndex - 1 + MaxSlots) % MaxSlots;
            Debug.Log("Выбран слот:" + selectedIndex);
        }
        else if (scroll < 0f)
        {
            selectedIndex = (selectedIndex + 1) % MaxSlots;
            Debug.Log("Выбран слот:" + selectedIndex);
        }

        for (int i = 0; i < MaxSlots; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedIndex = i;
                Debug.Log("Выбран слот:" + selectedIndex);
                break;
            }
        }

        ScrollControll.transform.position = inventory.Slots[selectedIndex].position;
    }

    public void Drop()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventory.IsFull[selectedIndex] == true)
            {
                DropedItem = Instantiate(inventory.inventory[selectedIndex].itemOnScene);
                DropedItem.transform.position = PlaceToDrop.transform.position;
                DropedItem.name = inventory.inventory[selectedIndex].NameItem;
                inventory.inventory[selectedIndex] = null;

                inventory.IsFull[selectedIndex] = false;

                Destroy(inventory.Icons[selectedIndex]);
                inventory.Icons[selectedIndex] = null;
                Debug.Log("Предмет в слоте:" + " " + selectedIndex + " " + "был выбрашен");

                manager.CollectItems -= 1;


            }
            else
            {
                Debug.Log("Инвентарь пуст");
            }
        }



    }
}
