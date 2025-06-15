using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStarter : MonoBehaviour
{
    private bool PlayerInZone;
    private GameObject Doors;
    private bool StartGame;
    private GameManager manager;

    public void Start()
    {
        Doors = GameObject.Find("Doors");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerInZone = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerInZone = false;
        }
    }

    public void Update()
    {
        if (PlayerInZone == true && Input.GetKeyDown(KeyCode.E) && StartGame == false)
        {
            Doors.SetActive(false);
            StartGame = true;
            Debug.Log("Игра Началась");       
        }
        else if (PlayerInZone == true && Input.GetKeyDown(KeyCode.E) && StartGame == true)
        {
            FinishGame();
        }                       
    }

    public void FinishGame()
    {
        StartGame = false;
        Doors.SetActive(true);
        manager.Day += 1;
        manager.ResultDay();
        Debug.Log("Игра окончена");
    }
}
