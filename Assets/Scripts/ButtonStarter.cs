using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStarter : MonoBehaviour
{
    private bool PlayerInZone;
    private GameObject Doors;

    public void Start()
    {
        Doors = GameObject.Find("Doors");
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
        if (PlayerInZone && Input.GetKey(KeyCode.E))
        {
            Destroy(Doors);
            Debug.Log("Игра Началась");       
        }
            

        
    }
}
