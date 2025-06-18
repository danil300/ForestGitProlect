using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStarter : MonoBehaviour
{
    private GameObject Doors;
    private bool StartGame;
    private GameManager manager;

    public void Start()
    {
        Doors = GameObject.Find("Doors");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SterterGame()
    {
        if (StartGame == false)
        {
            Doors.SetActive(false);
            StartGame = true;
        }
        else
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
