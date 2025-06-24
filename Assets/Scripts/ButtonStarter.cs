using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStarter : MonoBehaviour
{
    private GameObject Doors;
    private bool StartGame;
    private GameManager manager;

    public Animator doorsAnim;

    public void Start()
    {
        Doors = GameObject.Find("Doors");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SterterGame()
    {
        if (StartGame == false)
        {
            doorsAnim.SetBool("Start", true);
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
        doorsAnim.SetBool("Start", false);
        manager.Day += 1;
        manager.ResultDay();
        Debug.Log("Игра окончена");
    }
}
