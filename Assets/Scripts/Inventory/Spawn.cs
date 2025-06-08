using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private Transform PlaceToDrop;

    public void Start()
    {
        player = GameObject.Find("Player").transform;
        PlaceToDrop = GameObject.Find("PlaceToDrop").transform;
    }

    public void SpawnDroppedItem()
    {
        Instantiate(item, PlaceToDrop.transform.position, Quaternion.identity);
    }
}
