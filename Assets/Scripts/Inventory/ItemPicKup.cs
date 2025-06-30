using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicKup : MonoBehaviour
{
    public float PicKupDistance = 3f;
    public LayerMask LayerItems;
    public GameObject buttonEToButtonsStart;
    public GameObject buttonEToItems;

    public float InteractionDistance = 3f;
    public LayerMask LayerButton;

    private GameManager manager;
    private bool InventoryIsFull = false;
    private ButtonStarter buttonStarter;

    public Items[] AllItemsOnScene;

    private string Object;
    public Invnetory invent;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonStarter = GameObject.Find("Button").GetComponent<ButtonStarter>();
        buttonEToItems.SetActive(false);
        buttonEToButtonsStart.SetActive(false);

        invent = GetComponent<Invnetory>();
    }

    public void Update()
    {
        if (manager.CollectItems >= 4)
        {
            Debug.Log("Инвентарь пререполнен");
            InventoryIsFull = true;
        }
        else
        {
            InventoryIsFull = false;
        }

        PicKup();
        interactionsButton();
    }

    public void PicKup()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, PicKupDistance, LayerItems))
        {
            buttonEToItems.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && InventoryIsFull == false)
            {
                Destroy(hit.collider.gameObject);
                manager.CollectItems += 1;
                manager.MaxCollectItems += 1;
                manager.MaxCollectItemsDays += 1;
                buttonEToItems.SetActive(false);

                Object = hit.collider.gameObject.name;
                Debug.Log("Подоброн предмет:" + " " + Object);

                for (int i = 0; i < AllItemsOnScene.Length; i++)
                {
                    if (Object == AllItemsOnScene[i].NameItem)
                    {
                        invent.Adds(i);
                        break;
                    }
                    else
                    {
                        Debug.Log("Такой предмет не найден");
                    }
                }
            }          
        }
        else
        {
            buttonEToItems.SetActive(false);
        }

       
    }

    public void interactionsButton()
    {
        RaycastHit hitButton;

        if (Physics.Raycast(transform.position, transform.forward, out hitButton, InteractionDistance, LayerButton))
        {
            buttonEToButtonsStart.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Кнопка нажата");
                buttonStarter.SterterGame();
                buttonEToButtonsStart.SetActive(false);
            }
        }
        else
        {
            buttonEToButtonsStart.SetActive(false);
        }
    }
}
