using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Inventory inventory;
    private GameManager manager;
    public float IndexInventory;
    public int i;

    public void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {
        

        if (transform.childCount <= 0)
        {
            inventory.IsFull[i] = false;
        }

        foreach (Transform child in transform)
        {
            if (Input.GetKey(KeyCode.G))
            {
                child.GetComponent<Spawn>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
                manager.CollectItems -= 1;
            }
        }
    }

}
