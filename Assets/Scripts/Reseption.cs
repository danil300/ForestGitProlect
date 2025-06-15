using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseption : MonoBehaviour
{
    private GameManager manager;
    public static bool InReseption;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {
        DropToKvota();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InReseption = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InReseption = false;
        }
    }

    public void DropToKvota()
    {
        if (Input.GetKeyDown(KeyCode.Q) && InReseption)
        {
            manager.PlayerOhco += manager.CollectItems * 100;
            manager.CollectItems = 0;
            manager.MaxCollectItemsDays += 1;
            Debug.Log("Предметы сданы");
        }
    }
}
