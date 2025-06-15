using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollect : MonoBehaviour
{
    private bool itemComplet;//игрок находится в зоне досигаемости или нет?
    private GameManager manager;
    private bool InventoryIsFull;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            itemComplet = true;//игрок в зоне
            //при наводке на предмет он будет подсвечиваться,а также будет загораться кнопка, для того чтобы подобрать
            Debug.Log("E подобрать");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            itemComplet = false;//игрок не в зоне
        }
    }

    public void Update()
    {
        //если игрок в зоне нажмёт E 
        if (Input.GetKeyDown(KeyCode.E) && itemComplet && InventoryIsFull == false)
        {
            Destroy(gameObject);//объект уничтожится
            manager.CollectItems += 1;
            manager.MaxCollectItems += 1;
        }

        if (manager.CollectItems >= 4)
        {
            Debug.Log("Инвентарь пререполнен");
            InventoryIsFull = true;
        }

    }
}
