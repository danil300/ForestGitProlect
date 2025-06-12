using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    //создать отдельный класс для списка предметов куда будут вноситься предмет и его иконка, по иконке будут наследоваться нужный предмет, а по предмету нужная иконка
    private Inventory inventory;
    public static List<GameObject> ItemIconka = new List<GameObject>();
    private int IndexItem;
    private GameManager manager;
    private Transform PlaceToDrop;

    public GameObject Item;
    public GameObject ImageSlot;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlaceToDrop = GameObject.Find("PlaceToDrop").transform;
        
    }

    public void Update()
    {
        ScrollInput();
        DropInput();
    }

    void ScrollInput()
    {
        IndexItem = Mathf.Clamp(IndexItem, 0, 4);
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            IndexItem = (IndexItem + 1) % 4;
        }
        else if (scroll < 0f)
        {
            IndexItem = (IndexItem - 1 + 4) % 4;
        }


        switch (IndexItem)
        {
            case 0:
                ImageSlot.transform.position = inventory.slots[0].transform.position;
                break;
            case 1:
                ImageSlot.transform.position = inventory.slots[1].transform.position;
                break;
            case 2:
                ImageSlot.transform.position = inventory.slots[2].transform.position;
                break;
            case 3:
                ImageSlot.transform.position = inventory.slots[3].transform.position;
                break;

        }

        //отображение выбранного предмета
        Debug.Log("Выбран слот:" +  IndexItem);

    }

    void DropInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItem(IndexItem);
        }
    }

    void DropItem(int index)
    {
        switch (index)
        {
            case 0:
                if (inventory.IsFull[0] == true)
                {
                    Destroy(ItemIconka[0]);
                    ItemIconka.RemoveAt(0);
                    inventory.IsFull[0] = false;
                    manager.CollectItems -= 1;
                    Debug.Log("Выбрашен предмет в слоте 1");
                    Instantiate(Item, PlaceToDrop.position, Quaternion.identity);
                    
                }
                else
                {
                    Debug.Log("Слот пуст");
                }
                break;
            case 1:
                if (inventory.IsFull[1] == true)
                {
                    Destroy(ItemIconka[1]);
                    ItemIconka.RemoveAt(1);
                    inventory.IsFull[0] = false;
                    manager.CollectItems -= 1;
                    Debug.Log("Выбрашен предмет в слоте 2");
                    Instantiate(Item, PlaceToDrop.position, Quaternion.identity);

                }
                else
                {
                    Debug.Log("Слот пуст");
                }
                break;
            case 2:
                if (inventory.IsFull[2] == true)
                {
                    Destroy(ItemIconka[2]);
                    ItemIconka.RemoveAt(2);
                    inventory.IsFull[0] = false;
                    manager.CollectItems -= 1;
                    Debug.Log("Выбрашен предмет в слоте 3");
                    Instantiate(Item, PlaceToDrop.position, Quaternion.identity);

                }
                else
                {
                    Debug.Log("Слот пуст");
                }
                break;
            case 3:
                if (inventory.IsFull[3] == true)
                {
                    Destroy(ItemIconka[3]);
                    ItemIconka.RemoveAt(3);
                    inventory.IsFull[0] = false;
                    manager.CollectItems -= 1;
                    Debug.Log("Выбрашен предмет в слоте 4");
                    Instantiate(Item, PlaceToDrop.position, Quaternion.identity);
                 
                }
                else
                {
                    Debug.Log("Слот пуст");
                }
                break;
        }
    }
}
