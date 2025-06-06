using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float TimeToSpawn;
    public float Damage;
    public float HP;

    private NavMeshAgent agent;
    private GameObject player;
    private bool PlayerInZone;
    private Transform Spawn;
    private GameManager manager;
    private GameObject Enemy;
    private bool EnemyActive;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        Spawn = GameObject.Find("SpawnEnemy").transform;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Enemy = GameObject.Find("Enemy");

        StartCoroutine(SpawnEnemy());
    }

    public void Update()
    {
        if (EnemyActive)
        {
            if (PlayerInZone)
            {
                agent.destination = player.transform.position;
            }
            else
            {
                agent.destination = Spawn.position;
            }
        }
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerInZone = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerInZone = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            manager.PlayerHP -= 1;
            PlayerInZone = false;
            Debug.Log("Игрок атакован");
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(TimeToSpawn);
        agent.transform.position = Spawn.position;
        EnemyActive = true;
        Debug.Log("Враг заспавнился");
    }
}
