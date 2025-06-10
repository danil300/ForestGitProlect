using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseption : MonoBehaviour
{
    private GameManager manager;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "items")
        {
            manager.PlayerOhco += 100;
            Debug.Log("+ 100 очков");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "items")
        {
            manager.PlayerOhco -= 100;
            Debug.Log("- 100 очков");
        }
    }
}
