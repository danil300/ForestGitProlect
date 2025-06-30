using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invnetory : MonoBehaviour
{
    public Dictionary<int, Items> inventory = new Dictionary<int, Items>
    {
        {0, null },
        {1, null },
        {2, null },
        {3, null },
    };

    public Dictionary<int, GameObject> Icons = new Dictionary<int, GameObject>
    {
        {0, null },
        {1, null },
        {2, null },
        {3, null },
    };


    public Transform[] Slots;
    public bool[] IsFull;

    private ItemPicKup CollectItems;
    private int IndexFalseSlot;
    private GameObject Icon;
    private GameObject Catalog;

    public void Start()
    {
        CollectItems = GetComponent<ItemPicKup>();
        Catalog = GameObject.Find("Иконки предметов");
    }

    public void Adds(int indexItem)
    {
        for (int i = 0; i < IsFull.Length; i++)
        {
            if (IsFull[i] == false)
            {
                IndexFalseSlot = i;
                IsFull[IndexFalseSlot] = true;
                break;
            }
        }

        inventory[IndexFalseSlot] = CollectItems.AllItemsOnScene[indexItem];


        Icon = Instantiate(inventory[IndexFalseSlot].itemIcon, Catalog.transform);
        Icons[IndexFalseSlot] = Icon;
        Icon.transform.position = Slots[IndexFalseSlot].transform.position;

        Debug.LogFormat("В слот:" + " " + IndexFalseSlot + " " + "добавлен объект" + " " + CollectItems.AllItemsOnScene[indexItem].NameItem);



    }
}
